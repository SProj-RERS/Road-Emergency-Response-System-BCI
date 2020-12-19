using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public float throttle;
    public float steer;
    public static int counter = 0;
    // public ParticleSystem explosionFire;

    // void Start()
    // {
        // explosionFire.Stop();
    // }
    
    void OnTriggerEnter(Collider other) {
        if(other.tag == "othercar" || other.tag == "streetlight") {
            counter++;
        }
    }
    void Update () {
        if(counter <= 6) {
            // print(counter);
            throttle = Input.GetAxis("Vertical");
            steer = Input.GetAxis("Horizontal");
        }
        else{
            // print("fire!!!!");
            // explosionFire.Play();
            throttle = 0;
            steer = 0;
        }
    }
}
