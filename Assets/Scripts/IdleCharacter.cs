using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleCharacter : MonoBehaviour
{
    private Animator animation;
    private BoxCollider boxcollider;

    void Start()
    {
        boxcollider = GetComponent<BoxCollider>();
        animation = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider collision)
   {
       if(collision.tag == "maincar")
       {
            animation.runtimeAnimatorController = Resources.Load("Death") as RuntimeAnimatorController; 
            boxcollider.enabled = false;
            // animation.enabled = false;
       }
   }
}
