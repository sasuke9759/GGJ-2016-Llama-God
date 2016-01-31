using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnJam : MonoBehaviour 
{
	public Image image;
	bool isDown = false;
	float amount = 0.01f;

    public float negativeProgress, positiveProgress;

	// Use this for initialization
	void Start () 
	{
		image.fillAmount = 0.0f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Interact") && !isDown) 
		{
			//Move the icon up
			float pushBack = Random.Range(negativeProgress, positiveProgress);
			float result = Mathf.Clamp((amount + pushBack), 0.0f, 1.0f); 
			image.fillAmount += result;
			isDown = true;
			if (image.fillAmount == 1.0f) 
			{
				//Stop and destroy this object
				this.gameObject.SetActive(!isDown);
			}
		} 
		else 
		{
			isDown = false;
		}
	}
}
