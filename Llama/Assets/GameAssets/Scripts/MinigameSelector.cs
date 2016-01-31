using UnityEngine;
using System.Collections;

public class MinigameSelector : MonoBehaviour {
    [SerializeField]
    GameObject[] minigames;
	
	// Update is called once per frame
	public void ActivateMinigame (string title) {
	    foreach(GameObject minigame in minigames)
        {
            if (minigame.name.Contains(title))
            {
                minigame.SetActive(true);
            }
        }
	}
}
