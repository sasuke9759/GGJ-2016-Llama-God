using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour {

	public float timer;
	public Text text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer -= 0.01f;
		text.text = timer.ToString("0");
		if(timer <= 0)
		{

		}
	}
}
