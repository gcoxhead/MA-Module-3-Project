using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemExcaliber: MonoBehaviour
{
    [SerializeField]
    private GameBehaviour GameManager;
    
    [SerializeField]
    private GameObject _excaliber;

    [SerializeField]
    private GameObject _playerWeapon;

    [SerializeField]
    private GameObject _playerExcaliberWeapon;

    [SerializeField] 
    private
    GameObject _excaliberParticles;

    [SerializeField]
    public TMP_Text ProgressText;

    [SerializeField]
    private AudioManager audioBehaviour;

    [SerializeField]
    private Animator animator;

    // Start is called before the first frame update
    void Awake()
    {
        GameManager = GameObject.Find("Game Manager").GetComponent<GameBehaviour>();
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if(GameManager.spellEnabled == true)
        {
            if (collision.gameObject.name == "Player")
            {

                PlayParticles();
                GameManager.hasExcalibur = true;
                _playerWeapon.SetActive(false);
                _playerExcaliberWeapon.SetActive(true);

                animator.SetTrigger("trigExcaliber");

                Debug.Log("Excaliber Collected!");
                //GameManager.Items += 1;
                ProgressText.text = "Quest Complete! Escape to merlins cave.";

                audioBehaviour.playQuestComplete();

                Instantiate(_excaliberParticles, gameObject.transform.position, Quaternion.identity);
                Destroy(this.transform.gameObject);
            }

        }
        


    }

    void PlayParticles()
    {
        Instantiate(_excaliberParticles, gameObject.transform.position, Quaternion.identity);
        Debug.Log("Excaliber particles Played");
    }
}
