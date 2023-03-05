using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    private static UiController instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            MenuUI();
            DisableInventory();
        }
    }

    [SerializeField]

    private GameObject[] _UI;
    private bool inventoryActive = false ;
    
    // Start is called before the first frame update

    // Start is called before the first frame update
    
    
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!inventoryActive)
            {
                EnableInventory();
            }
            else
            {
                DisableInventory();
            }

        }

    }
    public void MenuUI()
    {
        _UI[0].SetActive(true);
        _UI[1].SetActive(false);
        _UI[2].SetActive(false);
        _UI[3].SetActive(false);
        _UI[4].SetActive(false);
        _UI[5].SetActive(false);
    }
    public void CharCustGUI()
    {
        _UI[0].SetActive(false);
        _UI[1].SetActive(true);
        _UI[2].SetActive(false);
        _UI[3].SetActive(false);
        _UI[4].SetActive(false);
    }

    public void ShieldGUI()
    {
        _UI[0].SetActive(false);
        _UI[1].SetActive(false);
        _UI[2].SetActive(true);
        _UI[3].SetActive(false);
        _UI[4].SetActive(false);
    }

    public void SwordGUI()
    {
        _UI[0].SetActive(false);
        _UI[1].SetActive(false);
        _UI[2].SetActive(false);
        _UI[3].SetActive(true);
        _UI[4].SetActive(false);
    }

   public void HUDActive()
    {
        _UI[0].SetActive(false);
        _UI[1].SetActive(true);
        _UI[2].SetActive(false);
        _UI[3].SetActive(false);
        _UI[4].SetActive(true);
    }

    public void GamePlayHUD()
    {
        _UI[0].SetActive(false);
        _UI[1].SetActive(false);
        _UI[2].SetActive(false);
        _UI[3].SetActive(false);
        _UI[4].SetActive(true);
        _UI[5].SetActive(false);

    }
    
    public void ShopUI()
    {
        _UI[0].SetActive(false);
        _UI[1].SetActive(false);
        _UI[2].SetActive(false);
        _UI[3].SetActive(false);
        _UI[4].SetActive(false);
        _UI[5].SetActive(true);

    }

    public void EnableInventory()
    {

        _UI[6].SetActive(true);
        inventoryActive = true;
    }

    public void DisableInventory()
    {
        _UI[6].SetActive(false);
        inventoryActive = false;
    }




}


