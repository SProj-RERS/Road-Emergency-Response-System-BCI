﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCharacterMotion : MonoBehaviour
{
    private BetterWaypointFollower waypointscript;
    private Animator animation;
    private BoxCollider boxcollider;
    void Start()
    {
        boxcollider = GetComponent<BoxCollider>();
        waypointscript = GetComponent<BetterWaypointFollower>();
        animation = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider collision)
   {
       if(collision.tag == "maincar")
       {
            waypointscript.enabled = false;
            boxcollider.enabled = false;
            animation.runtimeAnimatorController = Resources.Load("Death") as RuntimeAnimatorController; 
            // animation.enabled = false;
       }
   }
}
