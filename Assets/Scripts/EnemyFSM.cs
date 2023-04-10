using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState {  Patrol, AttackBase, ChasePlayer, AttackPlayer}

    public EnemyState currentState;

    public float distance;
    public float distanceToPlayer;
    public bool isChasing;
    public bool isAttacking;
    public bool isPatrolling;

    private void Start()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        distance = distanceToPlayer;
        currentState = EnemyState.Patrol;
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        distance = distanceToPlayer;

        if (currentState == EnemyState.Patrol)
        {
            Patrol();
        }

        //else if (currentState == EnemyState.AttackBase)
        
           // AttackBase();

        else if (currentState == EnemyState.ChasePlayer)
            ChasePlayer();

        else if (currentState == EnemyState.AttackPlayer)
            AttackPlayer();
    }

    public Sight sightSensor;
    public Transform baseTransform;
    public float baseAttackDistance;
    public float playerAttackDistance;
    public float playerChaseDistance;

    void Patrol()
    {
        isPatrolling = true;
        if (sightSensor.detectedObject != null)
        {
            currentState = EnemyState.ChasePlayer;

            float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);

            if (distanceToBase <= baseAttackDistance)
                currentState = EnemyState.AttackBase;
        }
        Debug.Log("Go To Base");
    } 
    
    //void AttackBase()
    //{
       // Debug.Log("Attack Base!");
    //}

    void ChasePlayer()
    {
        if(sightSensor.detectedObject == null)
        {
            currentState = EnemyState.Patrol;
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);

        distance = distanceToPlayer;

        if (distanceToPlayer <= playerAttackDistance)
        {
            currentState = EnemyState.AttackPlayer;
        }

        Debug.Log("Chase Player!");
    }

        void AttackPlayer()
    {
        if (sightSensor.detectedObject == null)
        {
            currentState = EnemyState.Patrol;
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        
        if (distanceToPlayer> playerAttackDistance* 1.1f)
            currentState = EnemyState.ChasePlayer;

        Debug.Log("Attack Player!");
    }

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
