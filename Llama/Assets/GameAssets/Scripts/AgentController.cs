using UnityEngine;
using System.Collections;

public class AgentController : MonoBehaviour {

    [SerializeField]
    public Transform target;
    [SerializeField]
    NavMeshAgent agent;

    GameObject elevator;
    KillController killCounter;

	public GameObject player;

	public bool murdered = false;

    public enum AgentState
    {
        Roam, Panic
    };

    public AgentState state = AgentState.Roam;

	public GameObject deadBody;

	void Start()
	{
		player = GameObject.Find("Player");
        elevator = GameObject.Find("Elevator");
        killCounter = GameObject.Find("KillCounter").GetComponent<KillController>();
	}
	// Update is called once per frame
	void Update () {
        if (state == AgentState.Panic)
        {
            if (target != elevator)
            {
                target = elevator.transform;
            }
            if ((target.position - transform.position).magnitude <= 0.1f)
            {
                killCounter.numberLeft--;
                Destroy(gameObject);
            }
        }

        if (agent != null) agent.destination = target.position;

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
