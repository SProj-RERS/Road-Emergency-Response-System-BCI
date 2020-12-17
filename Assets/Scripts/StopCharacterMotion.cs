using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopCharacterMotion : MonoBehaviour
{
    private BetterWaypointFollower waypointscript;
    private Animator animation;
    void Start()
    {
        waypointscript = GetComponent<BetterWaypointFollower>();
        animation = GetComponent<Animator>();
    }
    void OnTriggerEnter(Collider collision)
   {
       if(collision.tag == "maincar")
       {
            waypointscript.enabled = false;
            animation.runtimeAnimatorController = Resources.Load("Death") as RuntimeAnimatorController;
            // animation.enabled = false;
       }
   }
}
