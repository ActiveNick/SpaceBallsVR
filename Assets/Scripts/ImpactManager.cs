using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactManager : MonoBehaviour {

    IEnumerator OnCollisionEnter(Collision col)
    {
        // Play this when there is a collision
        AudioSource soundImpact = GetComponent<AudioSource>();
        var waitValue = (soundImpact.clip.length / 3);
        soundImpact.Play();

        ParticleSystem explosion = gameObject.GetComponent<ParticleSystem>();
        explosion.Play();

        var child = gameObject.transform.GetChild(0);
        LODGroup lodg = child.GetComponent<LODGroup>();
        for (int i = 0; i < lodg.GetLODs().Length; i++)
        {
            lodg.GetLODs()[i].renderers[0].enabled = false;
        }

        // Get rid of this object when we know the sound had time to play
        //gameObject.GetComponent<MeshRenderer>().enabled = false;  // First we hide it
        yield return new WaitForSeconds(waitValue);
        Destroy(gameObject);
    }

}
