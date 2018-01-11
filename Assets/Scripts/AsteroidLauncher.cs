using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class AsteroidLauncher : MonoBehaviour, IInputHandler
{
    public GameObject MyControllers;
    public GameObject Projectile;
    public int LaunchForce = 1;
    // Allowed shot interval to throttle users' shots
    public float shotsPerSec = 0.5f;
    public AudioSource soundFire; // Used to play a sound when we fire a projectile

    // Keep Track of the last shot time to throttle users' shots
    float LastShotTime = 0;

    // Use this for initialization
    void Start () {
        InputManager.Instance.PushFallbackInputHandler(gameObject);
    }

    void IInputHandler.OnInputDown(InputEventData eventData)
    {
        if ((Time.realtimeSinceStartup - LastShotTime) > (1 / shotsPerSec))
        {
            LastShotTime = Time.realtimeSinceStartup;
            Ray shootingRay;
            if (eventData.InputSource.TryGetPointingRay(eventData.SourceId, out shootingRay))
            {
                Fire(shootingRay);
            }
        }
    }

    void IInputHandler.OnInputUp(InputEventData eventData)
    {

    }

    /// <summary>
    /// Instantiates a projectile using the assigned prefab and shoots it using Unity physics.
    /// </summary>
    private void Fire(Ray ShootingRay)
    {
        // Create an instance of the shell and store a reference to it's rigidbody.
        Rigidbody projInstance = Instantiate(Projectile, ShootingRay.origin, Projectile.transform.rotation).GetComponent<Rigidbody>();
        projInstance.GetComponent<RandomRotator>().enabled = true;

        // Set the projectile's velocity to the launch force in the fire position's forward direction.
        projInstance.velocity = LaunchForce * ShootingRay.direction;

        soundFire.Play();
    }
}
