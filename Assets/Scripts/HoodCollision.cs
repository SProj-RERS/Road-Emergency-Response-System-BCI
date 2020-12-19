using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HoodCollision : MonoBehaviour
{
   public ParticleSystem explosionSmoke;
   public ParticleSystem explosionFire;
   public AudioClip crashSound;
   public AudioClip thudSound;
   private AudioSource carAudio;
   public int hits = 0;

   void Start()
   {
       explosionSmoke.Stop();
       explosionFire.Stop();
       carAudio = GetComponent<AudioSource>();
   }

    void OnTriggerEnter(Collider other)
    {       
        
        // print("????????????");
        if(other.tag == "othercar" || other.tag == "streetlight")
        {
            hits +=1;
            explosionSmoke.Play();
            
           if(hits == 3)
           {
               print(hits);
                explosionSmoke.Stop();
                explosionFire.Play();
            }
          

            transform.localRotation = Quaternion.Euler(-28.961f,0.002f,0f);
            float new_y = transform.localPosition.y - 0.51f;
            float new_z = transform.localPosition.z + 0.45f;
            transform.localPosition = new Vector3(0f,new_y,new_z);
            carAudio.PlayOneShot(crashSound, 1.0f);  
        }
        if(other.tag == "footpath")
        {
            carAudio.PlayOneShot(thudSound, 1.0f);
        }
    }
}
