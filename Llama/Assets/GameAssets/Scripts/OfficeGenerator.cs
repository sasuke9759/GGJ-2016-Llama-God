using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OfficeGenerator : MonoBehaviour
{
    [SerializeField]
    int level, numberOfHallways, numberOfOffices, minHallwayLength, maxHallwayLength;
    [SerializeField]
    GameObject hallwayPrefab, officePrefab, elevatorPrefab;
    [SerializeField]
    GameObject startHallway;
    [SerializeField]
    List<GameObject> requiredRooms;
    [SerializeField]
    List<GameObject> hallwayItems;

    List<GameObject> hallwayEndNodes;
    List<GameObject> hallways, offices, decals;
    GameObject elevator;

    bool shufflingRooms = false, madeWalls = false;
    int importance = 0;


    // right up left down
    public static Vector3[] directions = { new Vector3(.8f, 0, 0), new Vector3(0, 0, .8f), new Vector3(-.8f, 0, 0), new Vector3(0, 0, -.8f) };
    int previousDirection = -1;

    Random random = new Random();

    // Use this for initialization
    void Start()
    {
        hallwayEndNodes = new List<GameObject>();
        hallways = new List<GameObject>();
        offices = new List<GameObject>();
        GenerateFloor();

        InvokeRepeating("ShuffleWorker", .2f, .2f);
    }

    void ShuffleWorker()
    {
        try
        {
            AgentController agent = offices[Random.Range(0, offices.Count)].transform.parent.FindChild("Agent").GetComponent<AgentController>();
            if (agent != null)
            {
                agent.target = offices[Random.Range(0, offices.Count)].transform;
            }
        }
        catch { }
    }

    void GenerateFloor()
    {
        int hallwaysLeft = numberOfHallways;
        int officesLeft = numberOfOffices;
        hallwayEndNodes.Add(elevator);

        while (hallwaysLeft > 0)
        {
            GenerateHallways(hallwayEndNodes[Random.Range(0, hallwayEndNodes.Count)]);
            hallwaysLeft--;
        }

        RemoveDuplicateHallways();

        while (officesLeft > 0)
        {
            GenerateOffices();
            importance++;
            officesLeft--;
        }

        while (requiredRooms.Count > 0)
        {
            GenerateUniqueRoom(requiredRooms[0]);
            requiredRooms.RemoveAt(0);
        }

        while (hallwayItems.Count > 0)
        {
            GenerateHallwayItem(hallwayItems[0]);
            hallwayItems.RemoveAt(0);
        }

        shufflingRooms = true;

    }

    private void GenerateUniqueRoom(GameObject gameObject)
    {
        OfficeController office = Instantiate(gameObject).GetComponentInChildren<OfficeController>();
        office.placementOrder = importance;
        offices.Add(office.gameObject);
        office.hallways = hallways;
        office.PlaceRandomly();
    }

    private void GenerateHallwayItem(GameObject gameObject)
    {
        GameObject hallway = hallways[Random.Range(0, hallways.Count)];
        GameObject decal = (GameObject)Instantiate(gameObject, hallway.transform.position, Quaternion.Euler(new Vector3(90, 0, 0)));
        decals.Add(decal);
    }

    void LateUpdate()
    {
        if (shufflingRooms)
        {
            foreach (GameObject office in offices)
            {
                if (!office.GetComponent<OfficeController>().happyWithCurrentSpot)
                {
                    return;
                }
            }
            foreach (GameObject hallway in hallways)
            {
                hallway.GetComponent<HallwayController>().GenerateWalls();
            }
            madeWalls = true;
        }
    }

    private void GenerateHallways(GameObject startHallway)
    {
        hallwayEndNodes.Remove(startHallway);

        int hallwayLength = Random.Range(minHallwayLength, maxHallwayLength);
        List<int> directionChoices = new List<int>();
        for (int i = 0; i < 4; i++)
        {
            if ((i + 2) % 4 != previousDirection)
            {
                directionChoices.Add(i);
            }
        }

        int totalChoices = directionChoices.Count;
        for (int i = 0; i < Random.Range(1, totalChoices); i++)
        {
            if (startHallway == null) startHallway = gameObject;
            GameObject currentHallway = startHallway;
            int direction = Random.Range(0, directionChoices.Count);
            for (int j = 0; j < hallwayLength; j++)
            {
                
                currentHallway = (GameObject)Instantiate(hallwayPrefab, currentHallway.transform.position + directions[direction], Quaternion.Euler(new Vector3(90, 0, 0)));
                hallways.Add(currentHallway);
            }
            hallwayEndNodes.Add(currentHallway);
        }
    }

    private void GenerateOffices()
    {
        OfficeController office = Instantiate(officePrefab).GetComponentInChildren<OfficeController>();
        office.placementOrder = importance;
        offices.Add(office.gameObject);
        office.hallways = hallways;
        office.PlaceRandomly();
    }

    private void GenerateElevator()
    {
        GameObject elevator = Instantiate(elevatorPrefab);
    }

    private void RemoveDuplicateHallways()
    {
        for (int i = hallways.Count - 1; i >= 0; i--)
        {
            for (int j = hallways.Count - 1; j >= 0; j--)
            {
                if (i != j)
                {
                    if (hallways[i].transform.position == hallways[j].transform.position && hallways[j].activeSelf)
                    {
                        hallways[i].SetActive(false);
                    }
                }
            }
        }
        for (int i = hallways.Count - 1; i >= 0; i--)
        {
            if (!hallways[i].activeSelf)
            {
                Destroy(hallways[i]);
                hallways.Remove(hallways[i]);
            }
        }
    }
}
