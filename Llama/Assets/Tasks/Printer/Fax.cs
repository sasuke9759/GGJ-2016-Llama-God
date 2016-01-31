using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fax : MonoBehaviour 
{
	//fax numbers
	string numbers;
	public Text text;
	public AudioSource audioSource;
	public AudioClip audioClip;

	// Use this for initialization
	void Start () 
	{
		audioSource.clip = audioClip;
	}

	IEnumerator PlaySound()
	{
		audioSource.Play ();
		yield return new WaitForSeconds (audioSource.clip.length);
	}

	void OnGUI()
	{
		if (text.text.Length >= 10) 
		{
			//Stop the input
			StartCoroutine("PlaySound");
		}
	}
}
