using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    [SerializeField] 
    GameBehaviour gameBehaviour;
    [SerializeField]
    AudioSource audioSource;

    private Animation anim;


    void Start()
    {
        anim = GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //If player enters trigger box and has key, the gate will open.
        if (other.CompareTag("Player"))
        {
            //Call trap method to create the circle trap
            Debug.Log("Player has entered gate trigger");

            OpenGate();

        }
    }


   private void OpenGate()
    {
        if (gameBehaviour.hasKey == true)
        {
            anim.Play();
            audioSource.Play();
        }
        else
        {
            Debug.Log("No Key!)");
        }
            
    }











}
