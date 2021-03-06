using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HoodCollision : MonoBehaviour
{
   public ParticleSystem explosionSmoke;
   public ParticleSystem explosionFire;
   public AudioClip crashSound;
   public AudioClip thudSound;
   private AudioSource carAudio;
   public int hits = 0;
   public GameObject firetruck;
   public GameObject menuContainer;

   void Start()
   {
       explosionSmoke.Stop();
       explosionFire.Stop();
       carAudio = GetComponent<AudioSource>();
   }

   void finish()
   {
    //    UnityEditor.EditorApplication.isPlaying = false;
   }

    void gameover()
    {
       menuContainer.SetActive(true);
       Invoke("restart",10f);
    }
    void restart()
    {
        SceneManager.LoadScene(0);
    }

    void OnTriggerEnter(Collider other)
    {       
        if(other.tag == "othercar")
        {
            hits += 1;
            explosionSmoke.Play();
            
           if(hits == 4)
           {
                explosionSmoke.Stop();
                explosionFire.Play();
                Invoke("gameover",5.0f);

                if(transform.position.z > 490f)
                {
                    Instantiate(firetruck,new Vector3(-583f,17.4f,603.8f),Quaternion.Euler(0,90,0));
                    Invoke("finish",15.0f);
                }
                
                if(transform.position.z < 405f)
                {
                    Instantiate(firetruck,new Vector3(779f,17.4f,331f),Quaternion.Euler(0,270,0));
                    Invoke("finish",15.0f);
                }

            }

            transform.localRotation = Quaternion.Euler(-28.961f,0.002f,0f);
            float new_y = transform.localPosition.y - 0.51f;
            float new_z = transform.localPosition.z + 0.45f;
            transform.localPosition = new Vector3(0f,new_y,new_z);
            carAudio.PlayOneShot(crashSound, 1.0f);  
           
        }
        if(other.tag == "footpath" || other.tag == "bin" || other.tag == "end")
        {
            carAudio.PlayOneShot(thudSound, 1.0f);
        }
    }
}
