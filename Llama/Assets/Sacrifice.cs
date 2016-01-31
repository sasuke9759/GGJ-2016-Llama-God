using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Sacrifice : MonoBehaviour {
    [SerializeField]
    InputField input;

    public TriggerChooser playerChooser;

    [SerializeField]
    GameObject SacrificeWindow;
    KillController killCounter;
    GameObject SacrificeCircle;

    void Start()
    {
        playerChooser = GameObject.Find("Player").transform.FindChild("Trigger").GetComponent<TriggerChooser>();
        SacrificeCircle = GameObject.Find("SATAN")
        killCounter = GameObject.Find("KillCounter").GetComponent<KillController>();
    }

	// Use this for initialization
	public void CheckChant () {
        if (input.text.Equals("LLAMALLAMALLAMA"))
        {
            input.text = "";
            SacrificeWindow.SetActive(false);
            playerChooser.gameObject.SetActive(true);
            playerChooser.transform.parent.GetComponent<CharController>().enabled = true;
            playerChooser.transform.parent.FindChild("SATAN").gameObject.SetActive(false);
            playerChooser.selectedObject.transform.parent.parent.gameObject.SetActive(false);
            killCounter.killCount++;
        }
        else if ()
	}
}
