using UnityEngine;
using System.Collections;

public class murderAnim : MonoBehaviour {

	private bool murdering = false;

	public Animator charAnim;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		charAnim.SetBool("murdering", murdering);
	}

	public void setNotMurdering()
	{
		murdering = false;

	}

	public void setMurdering()
	{
		murdering = true;
	}
}
