using UnityEngine;
using System.Collections;

public class SpritePicker : MonoBehaviour {
    [SerializeField]
    SpriteRenderer renderer;
    [SerializeField]
    NavMeshAgent agent;

    [SerializeField]
    Sprite[] leftSprite, upSprite, rightSprite, downSprite;

    int index;

    void Awake()
    {
        index = Random.Range(0, leftSprite.Length);
    }


    // Update is called once per frame
    void FixedUpdate () {
	    if (Mathf.Abs(agent.velocity.x) > Mathf.Abs(agent.velocity.z))
        {
            if (agent.velocity.x > 0)
            {
                renderer.sprite = rightSprite[index];
            }
            else
            {
                renderer.sprite = leftSprite[index];
            }
        }
        else
        {
            if (agent.velocity.z < 0)
            {
                renderer.sprite = downSprite[index];
            }
            else
            {
                renderer.sprite = upSprite[index];
            }
        }
	}
}
