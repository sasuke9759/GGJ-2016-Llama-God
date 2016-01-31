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

		if (GetComponentInChildren<InteractiveObjects>().activated == true && GetComponentInChildren<InteractiveObjects>() != null)

		{
			player.GetComponent<murderAnim>().setMurdering();
			GetComponentInChildren<InteractiveObjects>().SetInactive();
		}
	}
}
