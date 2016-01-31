using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Create corotuines for us and launch them for us
/// </summary>
public class JobManager : MonoBehaviour 
{
    static JobManager instance = null;
    public static JobManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType(typeof(JobManager)) as JobManager;
                if (!instance)
                {
                    GameObject obj = new GameObject("JobManager");
                    instance = obj.AddComponent<JobManager>();
                }
            }
            return instance;
        }
    }

    void OnApplicationQuit()
    {
        instance = null;
    }
}

/// <summary>
/// Pausing stoping jobs with corotuines
/// </summary>
public class Job
{
    #region Fields
    private event System.Action<bool> jobCompelete;
    public System.Action<bool> JobCompleted
    {
        get { return jobCompelete; }
    }
    public bool Running { get; private set; }
    public bool Pause { get; private set; }
    private IEnumerator m_coroutine;
    private bool jobKilled;
    //Execute all child jobs before calling jobs complete event 
    private Stack<Job> childJobs;
    #endregion

    #region Constructors
    public Job(IEnumerator corotuine)
        : this(corotuine, true)
    {

    }

    public Job(IEnumerator coroutine, bool shouldStart)
    {
        this.m_coroutine = coroutine;
        if (shouldStart)
        {
            StartTask();
        }
    }
    #endregion

    #region StaticJobMakers
    public static Job JobMaker(IEnumerator coroutine)
    {
        return new Job(coroutine);
    }

    public static Job JobMaker(IEnumerator coroutine, bool shouldStart)
    {
        return new Job(coroutine, shouldStart);
    }
    #endregion 

    #region API
    public Job CreateAndAddChild(IEnumerator corotuine)
    {
        Job j = new Job(corotuine, false);
        addChildJob(j);
        return j;
    }

    public void addChildJob(Job childJob)
    {
        if (childJobs == null)
        {
            childJobs = new Stack<Job>();
            childJobs.Push(childJob);
        }
    }

    public void RemoveChildJob(Job childJob)
    {
        if (childJobs.Contains(childJob))
        {
            Stack<Job> childStack = new Stack<Job>(childJobs.Count - 1);
            Job[] allCurrentChildren = childStack.ToArray();
            System.Array.Reverse(allCurrentChildren);
            for (int i = 0; i < allCurrentChildren.Length; i++)
            {
                Job j = allCurrentChildren[i];
                if (j != childJob)
                {
                    childStack.Push(j);
                }
            }
            childJobs = childStack;
        }
    }

    public void StartTask()
    {
        Running = true;
        JobManager.Instance.StartCoroutine(DoWork());
    }

    public IEnumerator StartAsCoroutine()
    {
        Running = true;
        yield return JobManager.Instance.StartCoroutine(DoWork());
    }

    public void PauseJob()
    {
        Pause = true;
    }

    public void UnPauseJob()
    {
        Pause = false;
    }

    public void KillJob()
    {
        jobKilled = true;
        Running = false;
        Pause = false;
    }

    public void KillJob(float delayInSeconds)
    {
        int delay = (int)(delayInSeconds * 1000);
        new System.Threading.Timer(obj =>
        {
            lock (this)
            {
                KillJob();
            }
        }, null, delay, System.Threading.Timeout.Infinite);
    }
    #endregion

    #region PrivateMethods
    private IEnumerator DoWork()
    {
        yield return null;
        while (Running)
        {
            if (Pause)
            {
                yield return null;
            }
            else
            {
                if (m_coroutine.MoveNext())
                {
                    yield return m_coroutine.Current;
                }
                else
                {
                    if (childJobs != null)
                    {
                        yield return JobManager.Instance.StartCoroutine(RunChildJobs());
                        Running = false;
                    }
                }
            }
        }
        if (jobCompelete != null)
        {
            jobCompelete(jobKilled);
        }
    }

    private IEnumerator RunChildJobs()
    {
        if (childJobs != null && childJobs.Count > 0)
        {
            do
            {
                Job childJob = childJobs.Pop();
                yield return JobManager.Instance.StartCoroutine(childJob.StartAsCoroutine());
            } while (childJobs.Count > 0);
        }
    }
    #endregion
}