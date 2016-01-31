using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpritePicker : MonoBehaviour {
    [SerializeField]
    List<Sprite> spriteOptions;
    [SerializeField]
    SpriteRenderer renderer;

	// Use this for initialization
	void Start () {
        renderer.sprite = spriteOptions[Random.Range(0, spriteOptions.Count)];
	}
}
