using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class ShopWeaponsBehaviour : MonoBehaviour
{
    //Variables
    private GameObject Player;
    public bool isShopping;
    private int shopCredits;
    private int cost;

    [SerializeField]
    private TMP_Text shopCreditText;

    [SerializeField]
    private AudioManager audioBehaviour;

    [SerializeField]
    private TMP_Text dialogueText;

    [SerializeField]
    private UiController _uiController;

    [SerializeField]
    private CameraController _cameraController;

    [SerializeField]
    private GameBehaviour _gameBehaviour; 

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
            _cameraController.ViewShopWeaponCam();
            audioBehaviour.playShopWeapons();
            //enableShop();

        }

    }

    private void OnTriggerExit(Collider other)
    {
        //ShopUi is disabled and playerUI enabled
        //Player regains control of avatar
        if(other.CompareTag("Player"))
        {
            _cameraController.ViewPlayGameCam();
            
            audioBehaviour.playMusic();

            //disableShop();
        }
               
    }

    private void enableShop()
    {
        Debug.Log("Shop Enabled");

        dialogueText.text = "Weapon Shop. Be careful...";

        isShopping = true;

        //_uiController.ShopWeaponUI();

        _cameraController.ViewShopWeaponCam();

        shopCredits = _gameBehaviour._credits;

        Debug.Log("You have" + shopCredits + "Credits");

        Debug.LogFormat("Credits:{0}", shopCredits);
        shopCreditText.text = "Credits: " + shopCredits;
        audioBehaviour.playShopWeapons();

    }

    private void disableShop()
    {
        Debug.Log("Shop Disabled");
        isShopping = false;
        _uiController.GamePlayHUD();
        _cameraController.ViewPlayGameCam();
        audioBehaviour.playMusic();

        
    }

    void OnMouseOver()
    {
        print(gameObject.name);
    }

    public void BuySpeedPotion()
    {
        cost = 10;
        if (shopCredits < cost)
        {
            dialogueText.text = "You fool, you are pennyless!!!";
            Debug.Log("Not enough credits!");
            return;
        }

        else
        {
            shopCredits -= cost;
            shopCreditText.text = "Credits: " + shopCredits;
            _gameBehaviour.Credits -= cost;
            dialogueText.text = "Speed +10";

            //add +5 to player speed for this level
        }

    }

    public void BuyHealthPotion()
    {
        cost = 5;
        if (shopCredits < cost)
        {
            dialogueText.text = "You fool, you are pennyless!!!";
            Debug.Log("Not enough credits!");
            return;
        }
        else
        {
            shopCredits -= cost;
            shopCreditText.text = "Credits: " + shopCredits;
            _gameBehaviour.Credits -= cost;
            dialogueText.text = "Health +5";
            //add +10 to player health for this level
        }

    }
    public void BuyPowerPotion()
    {
        cost = 15;
        if (shopCredits < cost)
        {
            dialogueText.text = "You fool, you are pennyless!!!";
            Debug.Log("Not enough credits!");
            return;
        }

        else 
        {
            shopCredits -= cost;
            shopCreditText.text = "Credits: " + shopCredits;
            _gameBehaviour.Credits -= cost;
            dialogueText.text = "Power +15";
            //add +15 to players power for this level
        }

    }

}
