using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerChooser : MonoBehaviour {

	private List<GameObject> objectList = new List<GameObject>();

	static public GameObject selectedObject;

	private float newdist = 1000;



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < objectList.Count; i++)
		{
			
			if(Vector2.Distance(transform.position, objectList[i].transform.position) < newdist)
			{

				if (selectedObject != null)
				{
					selectedObject.GetComponent<Light>().enabled = false;
				}

				selectedObject = objectList[i];
			}
			if (objectList[i].gameObject == selectedObject)
			{

				newdist = Vector2.Distance(transform.position, objectList[i].transform.position);

			}
		}
		if (objectList.Count == 0)
		{
			selectedObject = null;
		}

		if (selectedObject != null)
		{
			selectedObject.GetComponent<Light>().enabled = true;
		}
	}

	public void ActivateInteractive()
	{

		if (selectedObject != null)
		{

			selectedObject.GetComponent<InteractiveObjects>().SetActive();

		}

	}


	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.tag == "Interactive")
		{
			objectList.Add(other.gameObject);
		}

	}

	void OnTriggerExit2D(Collider2D other)
	{
		
		if (other.gameObject.tag == "Interactive")
		{
			objectList.Remove(other.gameObject);
			other.GetComponent<Light>().enabled = false;
		}
		
	}

}
