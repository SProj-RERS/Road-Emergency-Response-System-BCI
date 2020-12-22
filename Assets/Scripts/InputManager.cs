using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float throttle;
    public float steer;
    public static int counter = 0;
    public bool l;
    public bool h;
    
    void OnTriggerEnter(Collider other) {
        if(other.tag == "othercar" || other.tag == "streetlight") {
            counter++;
        }
    }
    void Update () 
    {
        l = Input.GetKeyDown(KeyCode.L);
        h = Input.GetKeyDown(KeyCode.H);
        
        if(counter <= 6) 
        {
            throttle = Input.GetAxis("Vertical");
            steer = Input.GetAxis("Horizontal");
        }
        else
        {
            throttle = 0;
            steer = 0;
        }
    }
}
