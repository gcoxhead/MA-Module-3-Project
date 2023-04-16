using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    //Set variables and objects used during animation
    Animator animator;

    // Audio Sfx for animations
    public AudioSource sword;
    public AudioSource castSpell;
    public AudioSource takeDamage;
    public AudioSource playerDeath;

    //Volume 
    public float volume = 1.0f;
    public bool isHit;
    public bool finishedCoroutine = true;


    void Start()
    {
        //Create a reference to the animator component
        animator = GetComponent<Animator>();
        Debug.Log("Animator component loaded");
    }

    void Update()
    {
        CheckInputs();
    }
    public void CheckInputs()
    {
        CheckForwardInput();
        CheckBackwardInput();
        CheckJumpInput();
        CheckFireInput();
        CheckMeleeAttack();
        CheckPlayerHealth();
        CheckHasExcaliber();
        //CheckForImpact();
        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetBool("takenDamage", true);
            takeDamage.Play();

        }
        else
            ;
            //animator.SetBool("takenDamage", false);

    }
    public void CheckForwardInput()
    {
        
        //Check for forward input key
        if (Input.GetKey(KeyCode.UpArrow)|| Input.GetKey(KeyCode.W))
            {
               animator.SetBool("isRunning", true);
               Debug.Log("Player running!");
            }     
        else
        {
            animator.SetBool("isRunning", false);
        }        

     }
    public void CheckBackwardInput()
    {
        //Check for backward input key
        if (Input.GetKey(KeyCode.DownArrow)|| Input.GetKey(KeyCode.S))
            {
                animator.SetBool("isBackward", true);
                Debug.Log("Player moving Backward!");
            }
        else
        {
            animator.SetBool("isBackward", false);
        }

    }

    public void CheckRotationInput()
    {
        CheckLeftInput();
        CheckRightInput();

        void CheckLeftInput()
        {

            //Check for rotation input key
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                animator.SetBool("isTurningLeft", true);
                Debug.Log("Player turning left!");
            }
            else
            {
                animator.SetBool("isTurningLeft", false);
            }
        }

        void CheckRightInput()
        {

            //Check for rotation input key
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                animator.SetBool("isTurningRight", true);
                Debug.Log("Player turning right!");
            }
            else
            {
                animator.SetBool("isTurningRight", false);
            }
        }
    }
    public void CheckJumpInput()
    {
        if (Input.GetKey(KeyCode.J))
        {
            animator.SetBool("isJumping", true);
        }
        else     
            animator.SetBool("isJumping", false);
        

    }

    public void CheckFireInput()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isCastingSpell", true);
            castSpell.Play();
        }

        else 
            animator.SetBool("isCastingSpell", false);
        
    }

    public void CheckMeleeAttack()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool("isAttack", true);
            sword.Play();
        }

        else 
        
            animator.SetBool("isAttack", false);
        
    }

    public void CheckPlayerHealth()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            animator.SetBool("isDead", true);

            playerDeath.Play();
        }
        else
            animator.SetBool("isDead", false);
    }

    public void CheckHasExcaliber()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            animator.SetBool("hasExcaliber", true);
            
            
        }
        else
            animator.SetBool("hasExcaliber", false);
    }

    /*public void CheckForImpact()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            animator.SetBool("takenDamage", true);
            takeDamage.Play();

        }
        else
            animator.SetBool("takenDamage", false);
    }*/


    /*void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemySword")&& !isHit) //|(other.gameObject.CompareTag("EnemySword"))))
        {
            
            animator.SetBool("takenDamage", true);
            isHit = true;
        }

        else if (other.gameObject.CompareTag("Spike")&& !isHit)
        {
            
            animator.SetBool("takenDamage", true);
            isHit = true;
        }
    }*/

    /*void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("EnemySword"))   //|(other.gameObject.CompareTag("EnemySword"))))
        {

            isHit = false;
            animator.SetBool("takenDamage", false);
           
        }

        if (other.gameObject.CompareTag("Spike"))// && isHit)
        {
            isHit = false;
            animator.SetBool("takenDamage", false);
        }   


    }*/
    /*IEnumerator damageMyPlayer()
    {
        animator.SetBool("takenDamage", true);

        yield return new WaitForSeconds(0.5f);
        finishedCoroutine = true;
        print("MyCoroutine is now finished.");

    }*/
}







