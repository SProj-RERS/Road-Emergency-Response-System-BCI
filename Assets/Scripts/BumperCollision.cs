using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {       
        if(other.name == "Obstacle")
        {
            float xRange = 2f;
            float new_x = transform.localPosition.x + 0.1f;
            transform.localPosition = new Vector3(new_x,transform.localPosition.y,transform.localPosition.z);
        }
    }
}
