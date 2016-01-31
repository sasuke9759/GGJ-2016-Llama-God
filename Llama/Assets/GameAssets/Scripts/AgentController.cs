using UnityEngine;
using System.Collections;

public class AgentController : MonoBehaviour {

    [SerializeField]
    public Transform target;
    [SerializeField]
    NavMeshAgent agent;

	public GameObject player;

	void Start()
	{
		player = GameObject.Find("Player");
	}
	// Update is called once per frame
	void Update () {
        agent.destination = target.position;

		if (GetComponentInChildren<InteractiveObjects>() != null && GetComponentInChildren<InteractiveObjects>().activated == true)

		{
			player.GetComponent<murderAnim>().setMurdering();
			GetComponentInChildren<InteractiveObjects>().SetInactive();
		}
	}
}
