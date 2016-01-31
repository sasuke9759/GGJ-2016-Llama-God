using UnityEngine;
using System.Collections;

public class murderAnim : MonoBehaviour {

	public bool murdering = false;

	public Animator charAnim;

	public ParticleSystem blood;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void setNotMurdering()
	{
		murdering = false;
		charAnim.SetBool("murdering", murdering);
	}

	public void setMurdering()
	{
		murdering = true;
		charAnim.SetBool("murdering", murdering);
	}

	public void spewBlood()
	{
		blood.Stop();
		blood.Play();
	}

	public void stopBlood()
	{
		blood.Stop ();
	}
}
