﻿using System.Collections;
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
    public int dead = 0;

    void Start()
    {
        boxcollider = GetComponent<BoxCollider>();
        animation = GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider collision)
    {
       if(collision.tag == "maincar")
       {
            gameObject.tag = "deadcharacter";
            boxcollider.enabled = false;
            animation.runtimeAnimatorController = Resources.Load("Death") as RuntimeAnimatorController; 

            float new_x1 = character.position.x+10f;
            float new_y1 = character.position.y;
            float new_z1 = character.position.z;
            Instantiate(blood1,new Vector3(new_x1,new_y1,new_z1),character.rotation);

            float new_x2 = character.position.x+15f;
            float new_y2 = character.position.y;
            float new_z2 = character.position.z-18f;
            Instantiate(blood1,new Vector3(new_x2,new_y2,new_z2),character.rotation);

            if(character.position.z > 490f)
            {
                Instantiate(ambulance,new Vector3(-583f,10.8f,603.8f),Quaternion.Euler(0,90,0));
            }
            if(character.position.z < 405f)
            {
                Instantiate(ambulance,new Vector3(779f,10.8f,331f),Quaternion.Euler(0,270,0));
            }
            dead = 1;
       }
  
    }
    void Update()
    {
        if(dead == 1)
        {
            othercharacters = GameObject.FindGameObjectsWithTag("character");
            int i = 0;
            foreach (GameObject person in othercharacters)
            {
                // person.transform.position = new Vector3(0,0,0);
                person.transform.position = Vector3.MoveTowards(person.transform.position, new Vector3(transform.position.x+i,transform.position.y,transform.position.z+i), 50 * Time.deltaTime);
                i += 5;
            }
        }
    }
}
