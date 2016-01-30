using UnityEngine;
using System.Collections;

public class HallwayController : MonoBehaviour {
    [SerializeField]
    GameObject[] walls;
    bool kill = false;

	// Use this for initialization
	public void GenerateWalls () {
        for (int i = 0; i < OfficeGenerator.directions.Length; i++)
        {
            Collider[] checkNeighbors = Physics.OverlapSphere(transform.position + OfficeGenerator.directions[i], 0.01f);
            foreach (Collider neighbor in checkNeighbors)
            {
                if (neighbor.gameObject.tag == "room" || neighbor.gameObject.tag == "hallway")
                {
                    walls[i].SetActive(false);
                }
            }
        }
	}

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "hallway")
        {
            if (!collision.gameObject.GetComponent<HallwayController>().kill)
            {
                kill = true;
                Destroy(gameObject);
            }
        }
    }
}
