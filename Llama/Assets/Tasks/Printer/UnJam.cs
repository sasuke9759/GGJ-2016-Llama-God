using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnJam : MonoBehaviour 
{
	public Image image;
	bool isDown = false;
	float amount = 0.01f;
    GameObject Player;

    TaskManager taskManager;

    public float negativeProgress, positiveProgress;

	// Use this for initialization
	void Awake () 
	{
		image.fillAmount = 0.0f;
        Player = GameObject.Find("Player");
        taskManager = GameObject.Find("Tasks").GetComponent<TaskManager>();
    }
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Interact") && !isDown) 
		{
			//Move the icon up
			float pushBack = Random.Range(negativeProgress, positiveProgress);
			float result = Mathf.Clamp((amount + pushBack), -1f, 1.0f); 
			image.fillAmount += result;
			isDown = true;
			if (image.fillAmount == 1.0f) 
			{
                //Stop and destroy this object
                Player.GetComponent<CharController>().enabled = true;
                Player.transform.FindChild("Trigger").gameObject.SetActive(true);
                this.gameObject.SetActive(false);
                taskManager.CompleteTask("Unjam");
            }
		} 
		else 
		{
			isDown = false;
		}
	}
}
