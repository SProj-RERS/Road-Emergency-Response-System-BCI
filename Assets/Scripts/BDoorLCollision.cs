using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BDoorLCollision : MonoBehaviour
{
   public AudioClip crashSound;
   public AudioClip thudSound;
   private AudioSource carAudio;

   void Start()
   {
       carAudio = GetComponent<AudioSource>();
   }

    void OnTriggerEnter(Collider other)
    {       
        if(other.tag == "othercar" || other.tag == "streetlight")
        {
            transform.localRotation = Quaternion.Euler(-10f,0f,0f);
            carAudio.PlayOneShot(crashSound, 1.0f);
           
        }

        if(other.tag == "footpath")
        {
            carAudio.PlayOneShot(thudSound, 1.0f);
        }
    }

}