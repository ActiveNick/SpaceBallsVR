using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class PlanetInteraction : MonoBehaviour, IInputClickHandler {

    public bool IsRotating = false;
    public int RotationRate = 10;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        
        IsRotating = !IsRotating;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (IsRotating)
        {
            gameObject.transform.Rotate(0, RotationRate * Time.deltaTime, 0);
        }
	}
}
