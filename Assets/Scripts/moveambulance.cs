using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class moveambulance : MonoBehaviour
{
    //   speed = 25;
    // Start is called before the first frame update
    public Transform maincar;
    public int speed;
    public float new_x;
    public float new_z;
    public float new_y;
    void Start()
    {
        //print("Wtf?");
    }

    // Update is called once per frame
    void Update()
    {
        //  transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // print(maincar.position);
        speed = 100;
       new_x = (1)*maincar.position.x;
       print(maincar.position.x);
       new_z = (1)*maincar.position.z;
       new_y = maincar.position.y;
       transform.position = Vector3.MoveTowards(transform.position, new Vector3(new_x, 0, new_z), speed * Time.deltaTime);
    }
}
