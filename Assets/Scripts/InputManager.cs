using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
[RequireComponent(typeof(CarController))]

public class InputManager : MonoBehaviour
{
    public float throttle;
    public float steer;
    public int counter = 0;
    
    void OnTriggerEnter(Collider other) {
        if(other.tag == "othercar" || other.tag == "streetlight") {
            counter += 1;
        }
    }
    void Update () {
        if(counter < 8) {
            throttle = Input.GetAxis("Vertical");
            steer = Input.GetAxis("Horizontal");
        }
    }
}
