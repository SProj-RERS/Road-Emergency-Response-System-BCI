using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class moveambulance : MonoBehaviour
{
    public AudioClip ambSound;
    private AudioSource ambAudio;
    public Transform maincar;
    public int speed;
    public float new_x;
    public float new_z;
    public float new_y;

    void Start()
    {
        ambAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
       ambAudio.PlayOneShot(ambSound, 1.0f);
       speed = 100;
       new_x = (1)*maincar.position.x-30f;
       new_z = (1)*maincar.position.z-20f;
    // new_y = maincar.position.y+30f;
       transform.position = Vector3.MoveTowards(transform.position, new Vector3(new_x, transform.position.y, transform.position.z), speed * Time.deltaTime);
    //    transform.Translate(Vector3.forward * Time.deltaTime * speed);
    Invoke("LaunchProjectile", 30.0f);
    //    StartCoroutine(Example());
       
    //    Destroy(gameObject);

    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "end"){
            print("disappear");
            Destroy(gameObject);
            
        }
    }

    void LaunchProjectile()
    {
        Destroy (GameObject.FindWithTag("deadcharacter"));
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        
        // print("hi");
       
        // yield return new WaitForSeconds(15);
        
        // transform.position = Vector3.MoveTowards(transform.position, new Vector3(new_x+10000f, transform.position.y, transform.position.z), speed * Time.deltaTime);
        // print(Time.time);
    }
}
