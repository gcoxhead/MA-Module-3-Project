using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField]
    public Transform cam;

    private void Start()
    {
        // reference in start method
        //find main camera

    }


    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}
