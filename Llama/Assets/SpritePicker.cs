using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpritePicker : MonoBehaviour {
    [SerializeField]
    List<Sprite> spriteOptionsLeft, spriteOptionsUp, spriteOptionsRight, spriteOptionsDown;
    [SerializeField]
    SpriteRenderer renderer;
    

    int personIndex;

	// Use this for initialization
	void Start () {
        personIndex = Random.Range(0, spriteOptions.Count);
	}

    void Update()
    {

    }
}
