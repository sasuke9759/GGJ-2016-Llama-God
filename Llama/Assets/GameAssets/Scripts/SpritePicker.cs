using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpritePicker : MonoBehaviour {
    [SerializeField]
    List<Sprite> spriteOptionsLeft, spriteOptionsUp, spriteOptionsRight, spriteOptionsDown;
    [SerializeField]
    SpriteRenderer spriteRenderer;
    [SerializeField]
    NavMeshAgent agent;
    
    
    

    int personIndex;

	// Use this for initialization
	void Start () {
        personIndex = Random.Range(0, spriteOptionsLeft.Count);
	}

    void OnGUI()
    {
        
        if (Mathf.Abs(agent.velocity.x) > Mathf.Abs(agent.velocity.z))
        {
            if (agent.velocity.x < 0)
            {
                spriteRenderer.sprite = spriteOptionsLeft[personIndex];
            }
            if (agent.velocity.x > 0)
            {
                spriteRenderer.sprite = spriteOptionsRight[personIndex];
            }
        }
        else
        {
            if (agent.velocity.z > 0)
            {
                spriteRenderer.sprite = spriteOptionsUp[personIndex];
            }
            if (agent.velocity.z < 0)
            {
                spriteRenderer.sprite = spriteOptionsDown[personIndex];
            }
        }

    }
}
