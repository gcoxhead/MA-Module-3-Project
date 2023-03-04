using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class ShopBehaviour : MonoBehaviour
{
    //Variables
    private GameObject Player;
    private bool isShopping;

    [SerializeField]
    private UiController _uiController;

    [SerializeField]
    private CameraController _cameraController;

    Ray ray;
    RaycastHit selection;

   
   
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");

        
    }

    // Update is called once per frame
    void Update()
    {
        //Logic for buying items
        //Price is deducted from player inventory credits
        //Item is addded into player inventory script
        OnMouseOver();
    }

    private void OnTriggerEnter(Collider other)
    {

        //If player enters the shop collider.
        //Shop Scene UI is enabled and all other UI disabled.
        //Camera leaves player shoulder and repositions into the shop.
        //Player controller is disabled

        //Detect if player collides with the trap collider
        if (other.CompareTag("Player"))
        {
            //Call trap method to create the circle trap
            enableShop();
            
           
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //ShopUi is disabled and playerUI enabled
        //Player regains control of avatar
        if(other.CompareTag("Player"))
        {
            disableShop();
        }
        
        
        
    }

    private void enableShop()
    {
        Debug.Log("Shop Enabled");

        isShopping = true;
        _uiController.ShopUI();
        _cameraController.ViewShopCam();
        //PlayerController Disabled







    }

    private void disableShop()
    {
        Debug.Log("Shop Disabled");
        isShopping = false;
        _uiController.GamePlayHUD();
        _cameraController.ViewPlayGameCam();

        //PlayerController enabled
    }

    void OnMouseOver()
    {
        print(gameObject.name);
    }


}
