using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sight : MonoBehaviour
{
    public float distance;
    public float angle;
    public LayerMask objectsLayers;
    public LayerMask obstaclesLayers;
    public Collider detectedObject;

    
    // Update is called once per frame
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, distance, objectsLayers);

        for (int i = 0; i< colliders.Length; i++)
        {
            Collider collider = colliders[i];

            Vector3 directionToCollider = Vector3.Normalize(collider.bounds.center - transform.position);

            float angleToCollider = Vector3.Angle(transform.forward, directionToCollider);

            if (angleToCollider < angle)
            {
                if (!Physics.Linecast(transform.position, collider.bounds.center, out RaycastHit hit, obstaclesLayers))
                {
                    float dist = Vector3.Distance(collider.transform.position, transform.position);
                    print("Distance to other: " + dist);

                    Debug.DrawLine(transform.position, collider.bounds.center, Color.green);
                    detectedObject = collider;
                    break;
                }

                else
                {
                    Debug.DrawLine(transform.position, hit.point, Color.red);
                }
            }
            
        }

    }

    void OnDrawGizmos()
    {
        //Detection distance for enemy
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);

        //Right sight limit of enemy
        Gizmos.color = Color.blue;
        Vector3 rightDirection = Quaternion.Euler(0, angle, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, rightDirection * distance);

        //Left sight limit of enemy
        Gizmos.color = Color.green;
        Vector3 leftDirection = Quaternion.Euler(0, -angle, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, leftDirection * distance);

      
    }

}
