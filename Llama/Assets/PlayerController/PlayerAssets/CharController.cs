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


		}
		else{
			charAnim.SetBool("left", false);
		}


		if (Input.GetAxis("Horizontal") > 0)
		{
			directionpressed = "right";

		}
		else{
			charAnim.SetBool("right", false);
		}


		if (Input.GetAxis("Vertical") > 0)
		{
			directionpressed = "up";


		}
		else{
			charAnim.SetBool("up", false);
		}


		if (Input.GetAxis("Vertical") < 0)
		{
			directionpressed = "down";


		}
		else{
			charAnim.SetBool("down", false);
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
			player.GetComponent<Rigidbody2D>().AddForce(Vector2.right * walkingspeed);
		}
		if (charAnim.GetCurrentAnimatorStateInfo(0).IsName("LeftAnim"))
		{
			player.GetComponent<Rigidbody2D>().AddForce(Vector2.left * walkingspeed);
		}
		if (charAnim.GetCurrentAnimatorStateInfo(0).IsName("UpAnim"))
		{
			player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * walkingspeed);
		}
		if (charAnim.GetCurrentAnimatorStateInfo(0).IsName("DownAnim"))
		{
			player.GetComponent<Rigidbody2D>().AddForce(Vector2.down * walkingspeed);
		}

		if (Input.GetButtonDown("Jump"))
		{
			triggerscript.ActivateInteractive();
		}


	}
}
