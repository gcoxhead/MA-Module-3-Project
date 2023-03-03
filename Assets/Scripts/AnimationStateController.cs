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
        if (Input.GetKey("up"))
        {
            animator.SetBool("isRunning", true);
            Debug.Log("Player running!");
        }

        if (!Input.GetKey("up"))
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetKey("down"))
        {
            animator.SetBool("isBackward", true);
        }
        if (!Input.GetKey("down"))
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
          animator.SetBool("isAttack", false);
        }
    }



