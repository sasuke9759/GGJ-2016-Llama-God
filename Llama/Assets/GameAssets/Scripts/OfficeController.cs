using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class OfficeController : MonoBehaviour {

    [HideInInspector]
    public List<GameObject> hallways;

    float[] rotationAmounts = { 0, 90, 180, 270 };

    // Use this for initialization
    void OnTriggerStay2D(Collider2D collision)
    {
	    if (collision.gameObject.tag == "hallway" || collision.gameObject.tag == "room")
        {
            //if (GetComponent<Collider2D>().bounds.Contains(collision.gameObject.GetComponent<Collider2D>().bounds.center))
                PlaceRandomly();
        }
	}

    public void PlaceRandomly()
    {
        GameObject hallway = hallways[Random.Range(0, hallways.Count)];

        int randomVal = Random.Range(0, 4);
        Vector3 direction = OfficeGenerator.directions[randomVal];
        float rotation = rotationAmounts[randomVal];
        transform.parent.position = hallway.transform.position + direction;
        transform.parent.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
        transform.parent.Rotate(new Vector3(0, 0, 90));
        transform.parent.parent = hallway.transform;
    }
}
