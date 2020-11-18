using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoodCollision : MonoBehaviour
{
   public ParticleSystem explosionParticle;
   public AudioClip crashSound;
   public AudioClip thudSound;
   private AudioSource carAudio;

   void Start()
   {
       explosionParticle.Stop();
       carAudio = GetComponent<AudioSource>();
   }

    void OnTriggerEnter(Collider other)
    {       
        if(other.tag == "othercar" || other.tag == "streetlight")
        {
            transform.localRotation = Quaternion.Euler(-28.961f,0.002f,0f);
            float new_y = transform.localPosition.y - 0.51f;
            float new_z = transform.localPosition.z + 0.45f;
            transform.localPosition = new Vector3(0f,new_y,new_z);
            explosionParticle.Play();
            carAudio.PlayOneShot(crashSound, 1.0f);  
        }
        if(other.tag == "footpath")
        {
            carAudio.PlayOneShot(thudSound, 1.0f);
        }
    }
}
