﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(InputManager))]
public class BumperFCollision : MonoBehaviour
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
        if(other.tag == "othercar")
        {
            transform.localRotation = Quaternion.Euler(2.159f,-0.18f,-5.042f);
            float new_y = transform.localPosition.y - 0.05f;
            float new_x = transform.localPosition.x + 0.1f;
            transform.localPosition = new Vector3(new_x,new_y,0f);
            carAudio.PlayOneShot(crashSound, 1.0f);
        }
        if(other.tag == "streetlight" || other.tag == "footpath" || other.tag == "bin" || other.tag == "footbridge")
        {
            transform.localRotation = Quaternion.Euler(2.159f,-0.18f,-5.042f);
            float new_y = transform.localPosition.y - 0.05f;
            float new_x = transform.localPosition.x + 0.1f;
            transform.localPosition = new Vector3(new_x,new_y,0f);
            carAudio.PlayOneShot(thudSound, 1.0f); 
        }
    }
}