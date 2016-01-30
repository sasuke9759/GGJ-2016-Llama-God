using UnityEngine;
using System.Collections;

public class AgentController : MonoBehaviour {

    [SerializeField]
    public Transform target;
    [SerializeField]
    NavMeshAgent agent;
	
	// Update is called once per frame
	void Update () {
        agent.destination = target.position;
	}
}
