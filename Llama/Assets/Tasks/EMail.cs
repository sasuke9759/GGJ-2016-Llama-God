using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EMail : MonoBehaviour {

    string emailText;
    public AudioSource audioSource;
    public AudioClip audioClip;
    public int emailCharMin = 200;
    public string input;
    InputField emailBody;
    public GameObject emailWindow;

    public void SubmitEmail()
    {
        emailBody = gameObject.GetComponent<InputField>();
        if (emailBody.text.Length < emailCharMin)
        {
            //Strike to Character
            Debug.Log(emailBody.text);
            Debug.Log("NOT");
        }
        else {
            Debug.Log(emailBody.text);
            Debug.Log("OK");
        }

        emailWindow.SetActive(false);
    }

    public void CancelEmail()
    {
        emailWindow.SetActive(false);
        //Strike
    }

    IEnumerator PlaySound()
    {
        audioSource.Play();
        yield return new WaitForSeconds(audioSource.clip.length);
    }
}
