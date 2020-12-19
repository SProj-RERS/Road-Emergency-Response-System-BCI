using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movefiretruck : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform maincar;
    public int speed;
    public float new_x;
    public float new_z;
    public float new_y;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speed = 100;
       new_x = (1)*maincar.position.x;
       print(maincar.position.x);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(new_x, transform.position.y, transform.position.z), speed * Time.deltaTime);
        
    }
}
