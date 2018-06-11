using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechControl : MonoBehaviour {

    public SpeechManager speech;

    // Use this for initialization
    void Start () {
        StartCoroutine(SpeakIntroduction());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator SpeakIntroduction()
    {
        while (speech == null || !speech.isReady)
        {
            yield return null;
        }

        speech.Speak("Welcome to the planetarium! Look around and enjoy the wonders of our Solar System. Press the trigger on the controller to blow some shit up!");
    }
}
