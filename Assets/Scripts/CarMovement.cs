using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float speed = 20.0f;
    public float turnSpeed = 55.0f;
    public float horizontalInput;
    public float forwardInput;
    

    // Update is called once per frame
    void Update()
    {
         horizontalInput = Input.GetAxis("Horizontal");
         forwardInput = Input.GetAxis("Vertical");
         transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
         transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
