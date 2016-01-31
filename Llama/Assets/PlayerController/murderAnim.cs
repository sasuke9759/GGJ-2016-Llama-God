using UnityEngine;
using System.Collections;

public class murderAnim : MonoBehaviour {

	public bool murdering = false;

	public Animator charAnim;

	public ParticleSystem blood;

	public AudioSource source;
	public AudioClip knife;

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
		source.clip = knife;
		source.Play ();
	}

	public void stopBlood()
	{
		blood.Stop ();
	}
}
