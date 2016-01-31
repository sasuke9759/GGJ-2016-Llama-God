using UnityEngine;
using System.Collections;

public class LockRotation : MonoBehaviour {
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.rotation = Quaternion.Euler(90, 0, 0);
	}
}
