﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TriggerChooser : MonoBehaviour {

    [SerializeField]
	List<GameObject> objectList = new List<GameObject>();

	public GameObject selectedObject;

	private float newdist = 1000;



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		for (int i = 0; i < objectList.Count; i++)
		{
			if (objectList[i] == null || !objectList[i].activeInHierarchy)
            {
                objectList.Remove(objectList[i]);
            }

			if(Vector3.Distance(transform.position, objectList[i].transform.position) < newdist)
			{

				if (selectedObject != null)
				{
					selectedObject.GetComponent<Light>().enabled = false;
				}

				selectedObject = objectList[i];
			}
			if (objectList[i] == selectedObject)
			{

				newdist = Vector3.Distance(transform.position, objectList[i].transform.position);

			}
		}
		if (objectList.Count == 0)
		{
			selectedObject = null;
            newdist = 1000;
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


	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.tag == "Interactive")
		{
			objectList.Add(other.gameObject);
		}

	}

	void OnTriggerExit(Collider other)
	{
		
		if (other.gameObject.tag == "Interactive")
		{
			objectList.Remove(other.gameObject);
			other.GetComponent<Light>().enabled = false;
		}
		
	}

}
