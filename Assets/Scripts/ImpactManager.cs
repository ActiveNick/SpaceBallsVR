using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactManager : MonoBehaviour {

    IEnumerator OnCollisionEnter(Collision col)
    {
        Collider collider = GetComponent<Collider>();
        if (collider != null)
        {
            collider.enabled = false;
        }

        float waitValue = 0;
        // Play this when there is a collision
        AudioSource soundImpact = GetComponent<AudioSource>();
        if (soundImpact != null) { 
            waitValue = (soundImpact.clip.length / 3);
            soundImpact.Play();
        }

        // Play the explosion particle system
        ParticleSystem explosion = gameObject.GetComponent<ParticleSystem>();
        if (explosion != null)
        {
            explosion.Play();
        }

        // Loop through all the Level of Detail (LOD) group for all the children
        // LOD components, and disable their respective renderers to make the 
        // asteroid disappear.
        var child = gameObject.transform.GetChild(0);
        LODGroup lodg = child.GetComponent<LODGroup>();
        for (int i = 0; i < lodg.GetLODs().Length; i++)
        {
            lodg.GetLODs()[i].renderers[0].enabled = false;
        }

        // Get rid of this object when we know the sound had time to play and the
        // attached particle system is done too.
        yield return new WaitForSeconds(waitValue);
        Destroy(gameObject);
    }

}
