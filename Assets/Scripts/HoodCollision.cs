using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoodCollision : MonoBehaviour
{
   public ParticleSystem explosionParticle;
   public AudioClip crashSound;
   private AudioSource carAudio;

   void Start()
   {
       explosionParticle.Stop();
       carAudio = GetComponent<AudioSource>();
   }

    void OnTriggerEnter(Collider other)
    {       
        if(other.tag == "othercar")
        {
            transform.localRotation = Quaternion.Euler(-160f,0f,0f);
            explosionParticle.Play();
            Debug.Log("???????");
            carAudio.PlayOneShot(crashSound, 1.0f);
           
        }
    }


//    void OnCollisionEnter(Collision collisionInfo)
//    {
//        if(collisionInfo.collider.tag == "othercar")
//        {
//            explosionParticle.Play();
//            Debug.Log("???????");
           
//        }
//    }

    // void OnCollisionEnter(Collision collision)
    // {
    //     print("outside if");
    //     if(collision.collider.tag == "othercar")
    //     {
    //         print("inside if");
    //         collision.transform.localRotation = Quaternion.Euler(-160f,0f,0f);
    //     }
    // }
}
