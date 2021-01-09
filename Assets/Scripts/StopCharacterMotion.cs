using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StopCharacterMotion : MonoBehaviour
{
    private BetterWaypointFollower waypointscript;
    private Animator animation;
    private BoxCollider boxcollider;
    public Transform character;
    public GameObject blood1;
    public GameObject blood2;
    public GameObject ambulance;
    public GameObject[] othercharacters;
    public GameObject[] othercars;
    public int[] enteridle;
    public int dead = 0;
    public GameObject menuContainer;

    void Start()
    {
        boxcollider = GetComponent<BoxCollider>();
        waypointscript = GetComponent<BetterWaypointFollower>();
        animation = GetComponent<Animator>();
    }

    void gameover()
    {
        menuContainer.SetActive(true);
        Invoke("restart",40f);
    }
    void restart()
    {
        SceneManager.LoadScene(0);
    }
    void OnTriggerEnter(Collider collision)
   {
       if(collision.tag == "maincar")
       {
            gameObject.tag = "deadcharacter";
            waypointscript.enabled = false;
            boxcollider.enabled = false;
            animation.runtimeAnimatorController = Resources.Load("Death") as RuntimeAnimatorController; 

            Invoke("bloodInvoke1",2.0f);
            Invoke("bloodInvoke2",2.0f);

            if(character.position.z > 490f)
            {
                Instantiate(ambulance,new Vector3(-583f,10.8f,603.8f),Quaternion.Euler(0,90,0));
                // ambulance.position = Vector3.MoveTowards(ambulance.position,character.position,speed * Time.deltaTime);
            }
            if(character.position.z < 405f)
            {
                Instantiate(ambulance,new Vector3(779f,10.8f,331f),Quaternion.Euler(0,270,0));
                // ambulance.position = Vector3.MoveTowards(ambulance.position,character.position,speed * Time.deltaTime);
            }
            
            othercharacters = GameObject.FindGameObjectsWithTag("character");
            enteridle = new int[othercharacters.Length];
            for(int p=0; p<othercharacters.Length; p++)
            {
                enteridle[p] = 0;
            }
            dead = 1;
            Invoke("gameover",10.0f);
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
        Instantiate(blood2,new Vector3(new_x2,new_y2,new_z2),character.rotation);
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
            for(int p=0; p<total_alive; p++)
            {
                Animator person_animation;
                GameObject person = othercharacters[p];
                person_animation = person.GetComponent<Animator>();
                person.transform.LookAt(transform.position);
                Vector3 new_position = new Vector3(transform.position.x+i,transform.position.y,transform.position.z+j);
                if(enteridle[p] == 0)
                {
                    person_animation.runtimeAnimatorController = Resources.Load("Running") as RuntimeAnimatorController;
                    person.transform.position = Vector3.MoveTowards(person.transform.position, new_position, 50 * Time.deltaTime);
                    i += 7;
                    j += 6;
                }
                if(person.transform.position == new_position && enteridle[p] == 0)
                {
                    person_animation = person.GetComponent<Animator>();
                    person_animation.runtimeAnimatorController = Resources.Load("Idle") as RuntimeAnimatorController;
                    counter += 1;
                    enteridle[p] = 1;
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