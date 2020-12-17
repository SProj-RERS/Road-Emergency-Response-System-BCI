using UnityEngine;

public class CarCollision : MonoBehaviour
{
   public ParticleSystem explosionParticle;

   void Start()
   {
       explosionParticle.Stop();
   }

   void OnCollisionEnter(Collision collisionInfo)
   {
       if(collisionInfo.collider.name == "WoodCrate")
       {
           explosionParticle.Play();
       }
   }
}
