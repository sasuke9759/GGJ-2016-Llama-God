using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class QuickTimeEvents : MonoBehaviour 
{
    GameObject Player;
	public Image progress;
	public Text pressButtonNow;
	public float seconds = 0;
	public float timeEventDuration = 0;
	public bool coolDownNow = false;
    TaskManager taskManager;

    // Use this for initialization
    void Start () 
	{
        Player = GameObject.Find("Player");
        taskManager = GameObject.Find("Tasks").GetComponent<TaskManager>();
        progress.fillAmount = 0;
		pressButtonNow.gameObject.SetActive (false);
		StartCoroutine ("StartQuickTime");
	}

	IEnumerator StartQuickTime()
	{
		do 
		{
			coolDownNow = false;
			yield return new WaitForSeconds(seconds);
			yield return StartCoroutine("FireQuickTimeEvent");
		} while(progress.fillAmount < 1.0f);

        Player.GetComponent<CharController>().enabled = true;
        Player.transform.FindChild("Trigger").gameObject.SetActive(true);
        taskManager.CompleteTask("Meeting");
        gameObject.SetActive (false);
	}

	IEnumerator FireQuickTimeEvent()
	{
		pressButtonNow.gameObject.SetActive (true);
		yield return new WaitForSeconds (timeEventDuration);
		pressButtonNow.gameObject.SetActive (false);

		//Give cool down just incase we hit it at a weird time
		coolDownNow = true;
		yield return new WaitForSeconds (2);
	}

	void Update()
	{
		if (Input.GetButtonDown("Interact") == true && !coolDownNow) 
		{
			if (pressButtonNow.IsActive ()) 
			{
				progress.fillAmount += 0.25f;
				Debug.LogWarning ("Adding");
			} 
			else 
			{
				//TODO: Set strikes and then turn task off
				gameObject.SetActive (false);
			}
		}
	}
}