using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
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
        if(Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            GetComponent<Rigidbody>().AddRelativeForce(Vector3.back);
        }
    }
}