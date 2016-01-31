using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {
    [SerializeField]
    Vector3[] possibleRotations;

	// Use this for initialization
	void Start () {
        transform.rotation = Quaternion.Euler(possibleRotations[Random.Range(0, possibleRotations.Length)]);
	}
}
