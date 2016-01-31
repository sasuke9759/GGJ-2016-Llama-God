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
    public GameObject SacrificeCircle;

    void Start()
    {
        playerChooser = GameObject.Find("Player").transform.FindChild("Trigger").GetComponent<TriggerChooser>();
        SacrificeCircle = GameObject.Find("Player").GetComponent<CharController>().SATAN;
        SacrificeCircle.SetActive(true);
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
            SacrificeCircle.SetActive(false);
            playerChooser.selectedObject.transform.parent.parent.gameObject.SetActive(false);
            killCounter.killCount++;
        }
        else if (!SacrificeCircle.activeSelf)
        {
            SacrificeCircle.SetActive(true);
        }
	}
}
