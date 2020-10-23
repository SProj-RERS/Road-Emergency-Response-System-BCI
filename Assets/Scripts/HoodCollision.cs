using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoodCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {       
        if(other.tag == "othercar")
        {
            transform.localRotation = Quaternion.Euler(-160f,0f,0f);
        }
    }
    // void OnCollisionEnter(Collision collision)
    // {
    //     print("outside if");
    //     if(collision.collider.tag == "othercar")
    //     {
    //         print("inside if");
    //         collision.transform.localRotation = Quaternion.Euler(-160f,0f,0f);
    //     }
    // }
}
