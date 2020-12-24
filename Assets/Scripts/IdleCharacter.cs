using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleCharacter : MonoBehaviour
{
    private Animator animation;
    private BoxCollider boxcollider;
    public Transform character;
    public GameObject blood1;
    public GameObject blood2;
    public GameObject ambulance;
    public GameObject[] othercharacters;
    public GameObject[] othercars;
    public int dead = 0;

    void Start()
    {
        boxcollider = GetComponent<BoxCollider>();
        animation = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider collision)
    {
       if(collision.tag == "maincar" && dead != 1)
       {
            gameObject.tag = "deadcharacter";
            boxcollider.enabled = false;
            animation.runtimeAnimatorController = Resources.Load("Death") as RuntimeAnimatorController; 

            Invoke("bloodInvoke1",1.5f);
            Invoke("bloodInvoke2",1.5f);

            if(character.position.z > 490f)
            {
                Instantiate(ambulance,new Vector3(-583f,10.8f,603.8f),Quaternion.Euler(0,90,0));
            }
            if(character.position.z < 405f)
            {
                Instantiate(ambulance,new Vector3(779f,10.8f,331f),Quaternion.Euler(0,270,0));
            }
            othercharacters = GameObject.FindGameObjectsWithTag("character");
            dead = 1;
       }
  
    }

    void bloodInvoke1()
    {
        float new_x1 = character.position.x+10f;
        float new_y1 = character.position.y;
        float new_z1 = character.position.z;
        Instantiate(blood1,new Vector3(new_x1,new_y1,new_z1),character.rotation);
    }

    void bloodInvoke2()
    {
        float new_x2 = character.position.x+15f;
        float new_y2 = character.position.y;
        float new_z2 = character.position.z-18f;
        Instantiate(blood1,new Vector3(new_x2,new_y2,new_z2),character.rotation);
    }

    void Update()
    {
        if(gameObject.tag == "deadcharacter")
        {
            othercars = GameObject.FindGameObjectsWithTag("othercar");
            foreach (GameObject car in othercars)
            {
                if(car.GetComponent<BetterWaypointFollower>() != null)
                {
                    if(Mathf.Abs(transform.position.z - car.transform.position.z) <200f && Mathf.Abs(transform.position.x - car.transform.position.x) <200f)
                    {
                        car.GetComponent<BetterWaypointFollower>().enabled = false;                    
                    }
                }
            }
        }
        int total_alive = othercharacters.Length;
        int counter = 0;
        if(dead == 1)
        {
            int i = 0;
            int j = 0;
            int k = 1;
            int l = 0;
            foreach (GameObject person in othercharacters)
            {
                Animator person_animation;
                person_animation = person.GetComponent<Animator>();
                person.transform.LookAt(transform.position);
                person_animation.runtimeAnimatorController = Resources.Load("Running") as RuntimeAnimatorController;
                Vector3 new_position = new Vector3(transform.position.x+i,transform.position.y,transform.position.z+j);
                person.transform.position = Vector3.MoveTowards(person.transform.position, new_position, 100 * Time.deltaTime);
                i += 20%(k+1);
                j += 15%(k+l);
                k += 2;
                l += 1;

                if(person.transform.position == new_position)
                {
                    person_animation = person.GetComponent<Animator>();
                    person_animation.runtimeAnimatorController = Resources.Load("Idle") as RuntimeAnimatorController;
                    counter += 1;
                }
                person.tag = "idlecharacter";
            }
            if(counter == total_alive)
            {
                dead = 0;
            }
        }
    }
}
