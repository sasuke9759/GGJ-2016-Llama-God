using UnityEngine;
using System.Collections;

public class Copy : MonoBehaviour 
{
	int numberOfCopiesGoal = 0;
	int numberOfCurrentCopies = 0;
	public AudioClip audioClip;
	public AudioSource audioSource;
	//TODO: add task manager.

	// Use this for initialization
	void Start () 
	{
		numberOfCopiesGoal = Random.Range (3, 10);
		audioSource.clip = audioClip;
		StartCoroutine ("StartCopy");
	}

	IEnumerator StartCopy()
	{
		bool stop = false;
		do 
		{
			audioSource.Play();
			yield return new WaitForSeconds(audioSource.clip.length);
			numberOfCurrentCopies++;
			stop = Input.GetButtonDown("Interact");
		} while(!stop);

		//TODO: Check for copies here with the TaskManager...
	}
}
