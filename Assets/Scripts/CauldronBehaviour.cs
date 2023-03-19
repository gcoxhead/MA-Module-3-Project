using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;

public class CauldronBehaviour : MonoBehaviour
{
    private GameObject Player;

    private bool cauldronActive;
   
    [SerializeField]
    private AudioManager audioBehaviour;

    [SerializeField]
    private TMP_Text progressText;

    [SerializeField]
    private UiController _uiController;

    [SerializeField]
    private CameraController _cameraController;

    [SerializeField]
    private GameBehaviour _gameBehaviour;

    [SerializeField]
    private GameObject _activatedCauldron;
    
    [SerializeField]
    private GameObject _puffOfSmoke;

    [SerializeField]
    private GameObject _notActivatedCauldron;

    [SerializeField]
    private GameObject _excaliberShield;

    // Start is called before the first frame update
    void Awake()
    {
        Player = GameObject.Find("Player");
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
            //Call trap method to create the circle trap
            enableCauldron();

        }

    }

    private void OnTriggerExit(Collider other)
    {
        //ShopUi is disabled and playerUI enabled
        //Player regains control of avatar
        if (other.CompareTag("Player"))
        {
            disableCauldron();
        }

    }

    private void enableCauldron()
    {
        
        Debug.Log("Cauldron Enabled");

        if (_gameBehaviour.spellEnabled)
        {
            progressText.text = "You have unlocked Excaliber";

            cauldronActive = true;

            _notActivatedCauldron.SetActive(false);
  
            _activatedCauldron.SetActive(true);

            _puffOfSmoke.SetActive(true);

            _excaliberShield.SetActive(false);

        }
        else 
                 
        progressText.text = "You have yet to collect all Merlins potions. Return to your quest";
        cauldronActive = false;


        //_uiController.ShopUI();

        _cameraController.ViewCauldronCam();  

        //audioBehaviour.playCauldron();

    }

    private void disableCauldron()
    {
        Debug.Log("Shop Disabled");
        //isShopping = false;
        _uiController.GamePlayHUD();
        _cameraController.ViewPlayGameCam();

        if (cauldronActive)
            {
                progressText.text = "Collect Excaliber";
            }

        else
        progressText.text = "You have yet to collect all Merlins potions. Return to your quest";
        //audioBehaviour.playMusic();


    }










}

   


