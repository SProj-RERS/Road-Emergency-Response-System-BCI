using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Car : MonoBehaviour
{
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }
    
    void ProcessInput() 
    {
        if(Input.GetKey(KeyCode.D))
        {
            rigidbody.AddRelativeForce(Vector3.up);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            rigidbody.AddRelativeForce(Vector3.down);
        }
        else if(Input.GetKey(KeyCode.W))
        {
            rigidbody.AddRelativeForce(Vector3.right);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            rigidbody.AddRelativeForce(Vector3.left);
        }
    }
}
