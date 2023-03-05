using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBehaviour : MonoBehaviour
{


    [SerializeField]
    private CameraController _cameraController;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        
        //Detect if player collides with the trap collider
        if (other.CompareTag("Player"))
        {

            _cameraController.ViewCloseGameCam();

        }

    }

    private void OnTriggerExit(Collider other)
    {


        //Detect if player collides with the trap collider
        if (other.CompareTag("Player"))
        {

            _cameraController.ViewPlayGameCam();

        }

    }
}
