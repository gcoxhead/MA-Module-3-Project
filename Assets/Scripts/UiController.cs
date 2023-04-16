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
            TitleUi();
            DisableInventory();
        }
    }

    [SerializeField]

    private GameObject[] _UI;
    private bool inventoryActive = false;
    private bool questUiActive = false;
    private bool pauseUiActive = false;
    public bool damageUiActive = false;

    [SerializeField]
    private InventoryManager inventoryManager;

    [SerializeField]
    private FadeUI fadeUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!inventoryActive)
            {
                inventoryManager.ListItems();
                EnableInventory();
            }
            else
            {
                DisableInventory();
            }

        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!questUiActive)
            {
                _UI[8].SetActive(true);
                questUiActive = true;

            }
            else
            {
                _UI[8].SetActive(false);
                questUiActive = false;
            }

        }

        if (Input.GetKeyDown("escape"))
        {
            if (!pauseUiActive)
            {
                EnablePauseUI();
            }

            else
            {
                DisablePauseUI();
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            if (!damageUiActive)
            {
                _UI[11].SetActive(true);
                damageUiActive = true;
            }
            else
            {
                _UI[11].SetActive(false);
                damageUiActive = false;
            }

        }



    }
    public void TitleUi()
    {
        _UI[0].SetActive(false);
        _UI[1].SetActive(false);
        _UI[2].SetActive(false);
        _UI[3].SetActive(false);
        _UI[4].SetActive(false);
        _UI[5].SetActive(false);
        _UI[5].SetActive(false);
        _UI[7].SetActive(false);
        _UI[8].SetActive(false);
        _UI[10].SetActive(false);
        _UI[11].SetActive(true);
        questUiActive = false;
    }
    public void MenuUI()
    {
        _UI[0].SetActive(true);
        _UI[1].SetActive(false);
        _UI[2].SetActive(false);
        _UI[3].SetActive(false);
        _UI[4].SetActive(false);
        _UI[5].SetActive(false);
        _UI[5].SetActive(false);
        _UI[7].SetActive(false);
        _UI[8].SetActive(true);
        _UI[10].SetActive(false);
        //_UI[11].SetActive(false);
        questUiActive = true;
    }
    public void CharCustGUI()
    {
        _UI[0].SetActive(false);
        _UI[1].SetActive(true);
        _UI[2].SetActive(false);
        _UI[3].SetActive(false);
        _UI[4].SetActive(false);
        _UI[8].SetActive(false);
        _UI[10].SetActive(false);
        _UI[11].SetActive(false);
        questUiActive = false;
    }

    public void ShieldGUI()
    {
        _UI[0].SetActive(false);
        _UI[1].SetActive(false);
        _UI[2].SetActive(true);
        _UI[3].SetActive(false);
        _UI[4].SetActive(false);
        _UI[11].SetActive(false);
    }

    public void SwordGUI()
    {
        _UI[0].SetActive(false);
        _UI[1].SetActive(false);
        _UI[2].SetActive(false);
        _UI[3].SetActive(true);
        _UI[4].SetActive(false);
        _UI[11].SetActive(false);
    }

   public void HUDActive()
    {
        _UI[0].SetActive(false);
        _UI[1].SetActive(true);
        _UI[2].SetActive(false);
        _UI[3].SetActive(false);
        _UI[4].SetActive(true);
        _UI[5].SetActive(false);
        _UI[7].SetActive(false);
        _UI[10].SetActive(false);
        _UI[11].SetActive(false);
    }

    public void GamePlayHUD()
    {
        _UI[0].SetActive(false);
        _UI[1].SetActive(false);
        _UI[2].SetActive(false);
        _UI[3].SetActive(false);
        _UI[4].SetActive(true);
        _UI[5].SetActive(false);
        _UI[7].SetActive(false);
        _UI[10].SetActive(false);
        _UI[11].SetActive(false);
    }
    
    public void ShopUI()
    {
        _UI[0].SetActive(false);
        _UI[1].SetActive(false);
        _UI[2].SetActive(false);
        _UI[3].SetActive(false);
        _UI[4].SetActive(false);
        _UI[5].SetActive(true);
        _UI[11].SetActive(false);

    }

    public void WeaponShopUI()
    {
        _UI[0].SetActive(false);
        _UI[1].SetActive(false);
        _UI[2].SetActive(false);
        _UI[3].SetActive(false);
        _UI[4].SetActive(false);
        _UI[5].SetActive(false);
        _UI[7].SetActive(true);
        _UI[11].SetActive(false);

    }

    public void WinScreen()
    {
        _UI[0].SetActive(false);
        _UI[1].SetActive(false);
        _UI[2].SetActive(false);
        _UI[3].SetActive(false);
        _UI[4].SetActive(false);
        _UI[5].SetActive(false);
        _UI[7].SetActive(false);
        _UI[8].SetActive(false);
        _UI[9].SetActive(true);
        _UI[11].SetActive(false);
    }

    public void EnablePauseUI()
    {
        _UI[0].SetActive(false);
        _UI[1].SetActive(false);
        _UI[2].SetActive(false);
        _UI[3].SetActive(false);
        _UI[4].SetActive(false);
        _UI[5].SetActive(false);
        _UI[6].SetActive(false);
        _UI[7].SetActive(false);
        _UI[8].SetActive(false);
        _UI[9].SetActive(false);
        _UI[10].SetActive(true);
        _UI[11].SetActive(false);
        pauseUiActive = true;
    }
    public void DisablePauseUI()
    {
        GamePlayHUD();
        
        pauseUiActive = false;
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


