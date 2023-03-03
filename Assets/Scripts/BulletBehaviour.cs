using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    // Set variables
    public float onscreenDelay = 3f;
    public GameObject SpellExplosion;
    public float speed = 10.0f;

    void Start()
    {
        // Destroy the bulllet object after specified time 
        Destroy(this.gameObject, onscreenDelay);
        
    }

    private void Update()
    {
        //Fire Spell forward in front of the player 
        transform.Translate(Vector3.forward* speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //On collision with Enemy Destroy the projectile and play explode effect
        if (other.tag == "Enemy")
        {
            Destroy(this.gameObject);
            GameObject explode = Instantiate(SpellExplosion, transform.position, Quaternion.identity);
            explode.GetComponent<ParticleSystem>().Play();
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Destroy projectile on collision with any collider that isn't tagged as an enemy
        if (collision.gameObject.tag != "Enemy")
        {
            Destroy(this.gameObject);
        }

    }

}