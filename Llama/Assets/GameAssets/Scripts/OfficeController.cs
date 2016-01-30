using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class OfficeController : MonoBehaviour
{

    [HideInInspector]
    public List<GameObject> hallways;

    float[] rotationAmounts = { 0, 90, 180, 270 };

    public bool happyWithCurrentSpot = true;
    public int placementOrder;

    // Use this for initialization
    void FixedUpdate()
    {
        happyWithCurrentSpot = true;
    }

    void OnTriggerEnter(Collider collision)
    {
        //Debug.Log("Collide");
        if (collision.gameObject.tag == "hallway")
        {
            if (GetComponent<Collider>().bounds.Contains(collision.gameObject.GetComponent<Collider>().bounds.center))
                PlaceRandomly();
        }
        else if (collision.gameObject.tag == "room" && !collision.gameObject.Equals(gameObject))
        {
            try
            {
                if (collision.gameObject.GetComponent<OfficeController>().placementOrder < placementOrder)
                {
                    PlaceRandomly();
                }
            }
            catch { }
        }
    }

    public void PlaceRandomly()
    {
        happyWithCurrentSpot = false;
        GameObject hallway = hallways[Random.Range(0, hallways.Count)];

        int randomVal = Random.Range(0, 4);
        Vector3 direction = OfficeGenerator.directions[randomVal];
        float rotation = rotationAmounts[randomVal];
        transform.parent.position = hallway.transform.position + direction;
        transform.parent.rotation = Quaternion.Euler(new Vector3(90, 0, 0));
        transform.parent.Rotate(new Vector3(0, 0, rotation));
        transform.parent.parent = hallway.transform;
    }
}
