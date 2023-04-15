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

    //Volume 
    public float volume = 1.0f;


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

        //Check for backward input key
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("isBackward", true);
        }
        if (!Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("isBackward", false);
        }

        //Check for backward input key
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isBackward", true);
        }
        if (!Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isBackward", false);
        }



        if (Input.GetKey(KeyCode.J))
        {
            animator.SetBool("isJumping", true);
        }

        if (!Input.GetKey(KeyCode.J))
        {
            animator.SetBool("isJumping", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isCastingSpell", true);
            castSpell.Play();
        }

        if (!Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isCastingSpell", false);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool("isAttack", true);
            sword.Play();
        }

        if (!Input.GetKeyDown(KeyCode.Z))
        {
            animator.SetBool("isAttack", false);
        }

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
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("isBackward", true);
        }
        if (!Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("isBackward", false);
        }

        //Check for backward input key
        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isBackward", true);
        }
        if (!Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isBackward", false);
        }
    }
}



