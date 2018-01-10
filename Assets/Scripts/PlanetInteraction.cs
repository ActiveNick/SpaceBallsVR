using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class PlanetInteraction : MonoBehaviour, IInputClickHandler {

    public bool IsMoving = false;
    public int RotationRate = 10;
    public int OrbitingSpeed = 10;

    public void OnInputClicked(InputClickedEventData eventData)
    {
        IsMoving = !IsMoving;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (IsMoving)
        {
            gameObject.transform.Rotate(0, RotationRate * Time.deltaTime, 0);
            gameObject.transform.RotateAround(Vector3.zero, Vector3.up, OrbitingSpeed * Time.deltaTime);
        }
	}
}
