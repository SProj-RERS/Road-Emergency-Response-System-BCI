using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FDoorLCollision : MonoBehaviour
{
   public AudioClip crashSound;
   private AudioSource carAudio;

   void Start()
   {
       carAudio = GetComponent<AudioSource>();
   }

    void OnTriggerEnter(Collider other)
    {       
        if(other.tag == "othercar")
        {
            transform.localRotation = Quaternion.Euler(12f,0f,0f);
            carAudio.PlayOneShot(crashSound, 1.0f);
           
        }
    }

}