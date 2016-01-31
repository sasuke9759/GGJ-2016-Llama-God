using UnityEngine;
using System.Collections;

public class MinigameActivator : MonoBehaviour {
    [SerializeField]
    InteractiveObjects interactive;
    [SerializeField]
    string miniGameName;

    GameObject player;
    GameObject miniGame;

    void Awake()
    {
        player = GameObject.Find("Player");
        miniGame = GameObject.Find("Minigames");
    }
	// Update is called once per frame
	void Update () {
	    if (interactive.activated)
        {
            interactive.enabled = false;
            interactive.activated = false;
            player.GetComponent<CharController>().enabled = false;
            player.transform.FindChild("Trigger").gameObject.SetActive(false);
            miniGame.GetComponent<MinigameSelector>().ActivateMinigame(miniGameName);
        }
	}
}
