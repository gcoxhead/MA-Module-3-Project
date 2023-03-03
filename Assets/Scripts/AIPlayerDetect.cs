using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIPlayerDetect : MonoBehaviour
{
    // Start is called before the first frame update
    public NavMeshAgent _agent;
    private Transform PlayerTransform;
    private Animator animator;

    void Start()
    {
        //_agent = GetComponent<NavMeshAgent>();
        PlayerTransform = GameObject.Find("Player").transform;
        //animator.SetBool("isIdle", true);
        //Debug.Log("Boss is Idle");

    }

    private void OnTriggerStay(Collider other)
    {
            if (other.name == "Player" )
            {
            attack();
            }
    }

    private void Update()
    {
        // set _agent position

    }

    private void attack()
    {
        // set _agent position
        {
            if (_agent == null)
                Destroy(gameObject);

            else
                //animator.SetBool ("IsWalking", true);
                _agent.destination = PlayerTransform.position;
                Debug.Log("Player detected - attack!");
        }

    }

   

}
