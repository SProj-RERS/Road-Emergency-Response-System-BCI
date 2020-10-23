using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // print("helloooo");       
        if(other.tag == "othercar")
        {
            float xRange = 2f;
            float new_x = transform.localPosition.x + 0.1f;
            transform.localPosition = new Vector3(new_x,transform.localPosition.y,transform.localPosition.z);
        }
    }
    // void OnCollisionEnter(Collision collision)
    // {
    //     print("outside if");
    //     if(collision.collider.tag == "othercar")
    //     {
    //         print("inside if");
    //         float xRange = 2f;
    //         float new_x = transform.localPosition.x + 0.1f;
    //         collision.transform.localPosition = new Vector3(new_x,transform.localPosition.y,transform.localPosition.z);
    //     }
    // }
}
