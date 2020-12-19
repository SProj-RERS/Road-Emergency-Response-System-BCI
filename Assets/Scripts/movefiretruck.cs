using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movefiretruck : MonoBehaviour
{
    public AudioClip fireSound;
    private AudioSource fireAudio;
    public Transform maincar;
    public int speed;
    public float new_x;
    public float new_z;
    public float new_y;

    void Start()
    {
        fireAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       fireAudio.PlayOneShot(fireSound, 1.0f);
       speed = 100;
       new_x = (1)*maincar.position.x;
       print(maincar.position.x);
       transform.position = Vector3.MoveTowards(transform.position, new Vector3(new_x, transform.position.y, transform.position.z), speed * Time.deltaTime);
        
    }
}
