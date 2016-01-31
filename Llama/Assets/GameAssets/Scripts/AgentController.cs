using UnityEngine;
using System.Collections;

public class AgentController : MonoBehaviour {

    [SerializeField]
    public Transform target;
    [SerializeField]
    NavMeshAgent agent;

	public GameObject player;

	public bool murdered = false;

	public GameObject deadBody;

	void Start()
	{
		player = GameObject.Find("Player");
	}
	// Update is called once per frame
	void Update () {
        agent.destination = target.position;

		if (GetComponentInChildren<InteractiveObjects>() != null && GetComponentInChildren<InteractiveObjects>().activated == true && murdered == false)

		{
			player.GetComponent<murderAnim>().setMurdering();

			agent.destination = agent.transform.position;

			agent.enabled = false;

			murdered = true;



		}

		if (player.GetComponent<murderAnim>().murdering == false && murdered == true)
		{

			print ("IT SHOULD BE TURNING INTO A DEAD BODY NOW");

			Instantiate(deadBody, this.transform.position, this.transform.rotation);

			GetComponent<Collider>().enabled = false;
			transform.GetChild(0).GetComponent<Collider>().enabled = false;

            gameObject.SetActive(false);



		}
	}
}
