using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameBehaviour : MonoBehaviour
{
    private static GameBehaviour instance;
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
        }
    }

    [SerializeField]
    public GameBehaviour GameManager;

    [SerializeField]
    public Button Buy;

    [SerializeField]
    public HealthBar healthBar;

    [SerializeField]
    public int MaxItems = 1000;

    [SerializeField] 
    private int _itemsCollected = 0;

    [SerializeField]
    private int _playerHP = 100;

    [SerializeField]
    public int _credits = 100;

    [SerializeField]
    public TMP_Text HealthText;

    [SerializeField]
    public TMP_Text ItemText;

    [SerializeField]
    public TMP_Text ProgressText;

    [SerializeField]
    public TMP_Text CrText;
    

    // Start is called before the first frame update
    void Start()
    {
        //ItemText.text += _itemsCollected;
        HealthText.text = "Health:"; //+ _playerHP;
        CrText.text = ""+ _credits;
    }

    public int Items
    {
        get { return _itemsCollected; }
        set
        {
            _itemsCollected = value;
            Debug.LogFormat("Items:{0}", _itemsCollected);
            ItemText.text = "Items Collected: " + Items;

            if (_itemsCollected >= MaxItems)
            {
                ProgressText.text = "You've found all the items!";
                //NextSceneButton.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                ProgressText.text = "Item found, only " + (MaxItems - _itemsCollected) + " more!";
            }
        }
    }

    public int Credits
    {
        get { return _credits; }
        set
        {
            _credits = value;
            Debug.LogFormat("Coins:{0}", _credits);
            CrText.text = "" + Credits;

            {
                CrText.text = "" + ( _credits);
            }
        }
    }

    public int HP
    {
        get { return _playerHP; }
        set
        {
            _playerHP = value;
            HealthText.text = "Health: "; //+ HP;
            Debug.LogFormat("Lives: {0}", _playerHP);

            if(_playerHP <=0)
            {
                ProgressText.text = ("You failed your mission...");
                //respawn
                //RestartSceneButton.gameObject.SetActive(true);
                Time.timeScale = 0;
            }

            else
            {
                ProgressText.text = "Player damage taken";
                healthBar.SetHealth(_playerHP);
            } 

        }
    }


    /*public void RestartScene()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );

        Time.timeScale = 1f;
    }

    public void NextScene()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        Time.timeScale = 1f;
    }*/
}
