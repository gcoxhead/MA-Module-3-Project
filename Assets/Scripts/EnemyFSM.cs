using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    public enum EnemyState {  GoToBase, AttackBase, ChasePlayer, AttackPlayer}

    public EnemyState currentState;

    private void Update()
    {
        if (currentState == EnemyState.GoToBase)
            GoToBase();
        else if (currentState == EnemyState.AttackBase)
            AttackBase();
        else if (currentState == EnemyState.ChasePlayer)
            ChasePlayer();
        else if (currentState == EnemyState.AttackPlayer)
            AttackPlayer();
    }

    public Sight sightSensor;
    public Transform baseTransform;
    public float baseAttackDistance;
    public float playerAttackDistance;

    void GoToBase()
    {
        if (sightSensor.detectedObject != null)
        {
            currentState = EnemyState.ChasePlayer;

            float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);
            if (distanceToBase <= baseAttackDistance)
                currentState = EnemyState.AttackBase;
        }
        Debug.Log("Go To Base");
    } 
    
    void AttackBase()
    {
        Debug.Log("Attack Base!");
    }

    void ChasePlayer()
    {
        if(sightSensor.detectedObject == null)
        {
            currentState = EnemyState.GoToBase;
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
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
            currentState = EnemyState.GoToBase;
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        
        if (distanceToPlayer> playerAttackDistance* 1.1f)
            currentState = EnemyState.ChasePlayer;

        Debug.Log("Attack Player!");
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, playerAttackDistance);

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, baseAttackDistance);
    }


}
