using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoodCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {       
        if(other.name == "Obstacle")
        {
            transform.localRotation = Quaternion.Euler(-160f,0f,0f);
        }
    }
}
