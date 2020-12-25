using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class moveambulance : MonoBehaviour
{
    public AudioClip ambSound;
    private AudioSource ambAudio;
    public Transform maincar;
    public Transform cubeone;
    public Transform cubetwo;
    public int speed;
    public float new_x;
    public float new_z;
    public float new_y;
    public GameObject[] othercars;

    void Start()
    {
        ambAudio = GetComponent<AudioSource>();
        new_x = (1)*maincar.position.x-30f;
        new_z = (1)*maincar.position.z-20f;
    }

    // Update is called once per frame
    void Update()
    {   
       ambAudio.PlayOneShot(ambSound, 1.0f);
       speed = 100;

       transform.position = Vector3.MoveTowards(transform.position, new Vector3(new_x, transform.position.y, transform.position.z), speed * Time.deltaTime);
       Invoke("LaunchProjectile", 30.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "end")
        {
            print("disappear");
            Destroy(gameObject);
            UnityEditor.EditorApplication.isPlaying = false;
        }
    }

    void LaunchProjectile()
    {
        Destroy (GameObject.FindWithTag("deadcharacter"));
        Destroy (GameObject.FindWithTag("blood"));
        
        if(transform.position.z > 490f)
        {
            new_x = 950f;
            // transform.position = Vector3.MoveTowards(transform.position, new Vector3(cubeone.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
            // ambulance.position = Vector3.MoveTowards(ambulance.position,character.position,speed * Time.deltaTime);
        }
        if(transform.position.z < 405f)
        {
            new_x = -800f;
            // transform.position = Vector3.MoveTowards(transform.position, new Vector3(cubetwo.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
            // ambulance.position = Vector3.MoveTowards(ambulance.position,character.position,speed * Time.deltaTime);
        }
        // transform.Translate(Vector3.forward * Time.deltaTime * speed);
        othercars = GameObject.FindGameObjectsWithTag("othercar");
        foreach (GameObject car in othercars)
        {
            if(car.GetComponent<BetterWaypointFollower>() != null)
            {
                car.GetComponent<BetterWaypointFollower>().enabled = true;
            }
        }
    }
}
