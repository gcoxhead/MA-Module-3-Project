using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState {  Patrol, ChasePlayer, AttackPlayer}

    public EnemyState currentState;
    public NavMeshAgent navMeshAgent;
    public float distance;
    public float distanceToPlayer;
    public Sight sightSensor;
    public float playerAttackDistance;
    public float playerChaseDistance;

    private void Start()
    {
        distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        distance = distanceToPlayer;
        currentState = EnemyState.Patrol;
    }

    private void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);

        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.Patrol;
            navMeshAgent.speed = 1;

            return;
            
        }

        else if (distanceToPlayer > playerChaseDistance)
        {
            currentState = EnemyState.Patrol;
            navMeshAgent.speed = 1;
        }

        else if (distanceToPlayer < playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
            navMeshAgent.speed = 4;
        }
        
        else if (distanceToPlayer>playerAttackDistance && distanceToPlayer<playerChaseDistance)
        {
                currentState = EnemyState.ChasePlayer;
                navMeshAgent.speed = 2;
                     
        }
        
    }
      

   /* void Patrol()
     
    /*void ChasePlayer()
   

       /* void AttackPlayer()
            
    }*/

    private void OnDrawGizmos()
    {
        //Draw a cyan wire sphere to show boundary of enemy sight to trigger an attack player.
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);

        //Draw a magenta wire sphere to show boundary of enemy sight to trigger enemy to chase player.
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, playerChaseDistance);
    }


}
