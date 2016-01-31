using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class KillController : MonoBehaviour {

    public Text killCounter;
    public int killCount = 0;
    public int numberLeft;

    OfficeGenerator officeGen;

    void Start()
    {
        officeGen = GameObject.Find("Elevator").GetComponent<OfficeGenerator>();
        numberLeft = officeGen.numberOfOffices;
    }

	// Use this for initialization
	void OnGUI () {
        killCounter.text = killCount + "/" + numberLeft;
	}
}
