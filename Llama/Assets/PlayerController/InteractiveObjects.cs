using UnityEngine;
using System.Collections;

public class InteractiveObjects : MonoBehaviour {

	public bool activated = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetActive()
	{
		if (activated != true){
			activated = true;
			print (name + " Activated");

		}
	}

	public void SetInactive()
	{
		activated = false;
	}
}
