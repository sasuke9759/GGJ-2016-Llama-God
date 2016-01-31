using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;




public class TaskManager : MonoBehaviour
{

    public static int numberOfCopies = 0;
    public static int numberOfCoWorkers = 0;

    public static List<string> taskStrings = new List<string>() {
        "Copies to Makes: " + numberOfCopies,
        "Send Fax to Corporate",
        "Un-Jam the Printer",
        "E-mail your Co-Worker",
        "Attend the Meeting",
		//"Kill Some Co-Workers: " + numberOfCoWorkers
	};

    public static List<string> taskTitles = new List<string>()
    {
        "Copy", "Fax", "Unjam", "Email", "Meeting"
    };

    public class Task
    {
        public string taskName;
        public bool isCompleted = false;
        public Task(string name)
        {
            taskName = name;
        }
    }

    public List<Task> tasks = new List<Task>();
    public List<GameObject> strikes = new List<GameObject>();
    public int numberOfTasks;
    public GameObject prefabTaskText;
    public GameObject taskSheet;
    public Animator animator;

    float speed = 0.3f;

    Vector3 startingPos = new Vector3((Screen.width * 2), (Screen.height / 2), 0);
    Vector3 endingPos = new Vector3((Screen.width), (Screen.height / 2), 0);
    Vector3 currentPos;

    // Use this for initialization
    void Start()
    {
        int taskIndex = 0;

        //Add the tasks
        for (int i = 0; i < numberOfTasks; i++)
        {

            taskIndex = Random.Range(0, taskStrings.Count - 1);


            Task task = new Task(taskStrings[taskIndex]);

            tasks.Add(task);

            //Create GUI to show tasks
            prefabTaskText.GetComponentInChildren<Text>().text = task.taskName;
            var clone = Instantiate(prefabTaskText, Vector3.zero, Quaternion.identity) as GameObject;
            clone.name = (taskTitles[taskIndex]);
            clone.transform.SetParent(this.gameObject.transform);
            //clone.GetComponent<RectTransform>().anchoredPosition = new Vector3 (0, 50 - (i * 30), 0);

            taskStrings.RemoveAt(taskIndex);
            taskTitles.RemoveAt(taskIndex);
        }
    }

    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, currentPos, speed);

        if (Input.GetButton("Menu"))
        {
            animator.SetBool("Open", true);
        }
        else
        {
            animator.SetBool("Open", false);
        }
    }

    public void CompleteTask(string taskName)
    {
        foreach (Transform task in transform)
        {
            if (task.gameObject.name.Equals(taskName))
            {
                task.GetComponentInChildren<Toggle>().isOn = true;
            }
        }
    }
}



