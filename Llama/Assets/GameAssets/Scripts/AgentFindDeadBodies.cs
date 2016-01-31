using UnityEngine;
using System.Collections;

public class AgentFindDeadBodies : MonoBehaviour {
    [SerializeField]
    AgentController agent;

    // Use this for initialization
    void OnTriggerStay(Collider other) {

        if (other.gameObject.tag.Equals("body"))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, (other.transform.position - transform.position), out hit, 10f))
            {
                if (hit.transform.gameObject.tag.Equals("body"))
                {
                    PanicAgent();
                }
            }
        }
        if (other.gameObject.tag.Equals("agent"))
        {
            if (other.GetComponent<AgentController>().state == AgentController.AgentState.Panic)
            {
                PanicAgent();
            }
        }
    }

    private void PanicAgent()
    {
        agent.state = AgentController.AgentState.Panic;
        agent.GetComponentInChildren<SpriteRenderer>().color = Color.yellow;
        //gameObject.SetActive(false);
    }
}
