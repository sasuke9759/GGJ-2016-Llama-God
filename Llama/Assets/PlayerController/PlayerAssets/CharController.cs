using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {
	// whether or not a direction is pressed
	private bool walking = false;

	// direction pressed
	private string directionpressed;

	// initiallize animator
	public Animator charAnim;
	public GameObject player;

    public GameObject SATAN;

	// walking speed

	public float walkingspeed;

	public TriggerChooser triggerscript;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		CheckDirection();
	}

	void CheckDirection ()
	{
		if (Input.GetAxis("Horizontal") < 0)
		{
			directionpressed = "left";

			charAnim.SetBool("up", false);
			charAnim.SetBool("down", false);
			charAnim.SetBool("right", false);
		}



		if (Input.GetAxis("Horizontal") > 0)
		{
			directionpressed = "right";

			charAnim.SetBool("up", false);
			charAnim.SetBool("down", false);
			charAnim.SetBool("left", false);
		}



		if (Input.GetAxis("Vertical") > 0)
		{
			directionpressed = "up";

			charAnim.SetBool("down", false);
			charAnim.SetBool("left", false);
			charAnim.SetBool("right", false);

		}



		if (Input.GetAxis("Vertical") < 0)
		{
			directionpressed = "down";

			charAnim.SetBool("up", false);
			charAnim.SetBool("left", false);
			charAnim.SetBool("right", false);
		}



		if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
		{
			directionpressed = null;
			walking = false;
		}else{
			walking = true;
			charAnim.SetBool(directionpressed, true);
		}

		charAnim.SetBool("walking", walking); 

		if (charAnim.GetCurrentAnimatorStateInfo(0).IsName("RightAnim"))
		{
			player.GetComponent<Rigidbody>().AddForce(Vector3.right * walkingspeed);
		}
		if (charAnim.GetCurrentAnimatorStateInfo(0).IsName("LeftAnim"))
		{
			player.GetComponent<Rigidbody>().AddForce(Vector3.left * walkingspeed);
		}
		if (charAnim.GetCurrentAnimatorStateInfo(0).IsName("UpAnim"))
		{
			player.GetComponent<Rigidbody>().AddForce(Vector3.forward * walkingspeed);
		}
		if (charAnim.GetCurrentAnimatorStateInfo(0).IsName("DownAnim"))
		{
			player.GetComponent<Rigidbody>().AddForce(Vector3.back * walkingspeed);
		}

		if (Input.GetButtonDown("Interact"))
		{
			triggerscript.ActivateInteractive();
		}


	}
}
