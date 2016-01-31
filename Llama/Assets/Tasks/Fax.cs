using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fax : MonoBehaviour 
{
	public AudioSource audioSource;
	public AudioClip audioClip;
    public int emailCharMin = 10;
    public string input;
    InputField faxNumber;
    public GameObject faxWindow;

    GameObject Player;
    TaskManager taskManager;

    public void SendFax()
    {
        faxNumber = gameObject.GetComponent<InputField>();
        if (faxNumber.text.Length == emailCharMin)
        {
            //Strike to Character
            Debug.Log(faxNumber.text);
            Debug.Log("OK");
            taskManager.CompleteTask("Fax");
        }
        else {
            Debug.Log(faxNumber.text);
            Debug.Log("NOT");
        }

        Player.GetComponent<CharController>().enabled = true;
        Player.transform.FindChild("Trigger").gameObject.SetActive(true);
        faxWindow.SetActive(false);
        gameObject.SetActive(false);
    }

    public void CancelFax()
    {
        faxWindow.SetActive(false);
        //Strike
    }

    // Use this for initialization
    void Start() 
	{
        Player = GameObject.Find("Player");
        taskManager = GameObject.Find("Tasks").GetComponent<TaskManager>();
        //audioSource.clip = audioClip;
    }

	IEnumerator PlaySound()
	{
		//audioSource.Play ();
		yield return new WaitForSeconds (audioSource.clip.length);
	}
}
