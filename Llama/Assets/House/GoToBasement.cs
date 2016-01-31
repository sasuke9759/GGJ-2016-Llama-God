using UnityEngine;
using System.Collections;

public class GoToBasement : MonoBehaviour {

	void OnCollisionEnter(Collision collision) 
	{
		Application.LoadLevel ("Basement");
	}
}
