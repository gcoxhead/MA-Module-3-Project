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
    public int MaxItems = 3;

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

    public bool spellEnabled = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
        HealthText.text = "Health:"; //+ _playerHP;
        CrText.text = ""+ _credits;
    }

    private void Update()
    {
        //if (Input.GetKey("escape"))
       // {
            //Application.Quit();
        //}

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
                ProgressText.text = "You've found all the potions! Unlock excaliber";
                //NextSceneButton.gameObject.SetActive(true);
                spellEnabled = true;
                //Time.timeScale = 0f;
            }
            else
            {
                ProgressText.text = "You've found a potion, only " + (MaxItems - _itemsCollected) + " left!";
                spellEnabled = false;
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

    public void QuitGame()
    {
        Application.Quit();
    }


    public void RestartScene()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );

        Time.timeScale = 1f;
    }

    //public void NextScene()

   // {
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

      //  Time.timeScale = 1f;
    //}*/
}
