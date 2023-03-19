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
    private AudioSource _collectExcaliber;

    [SerializeField]
    private AudioSource _questCompleteMusic;

    [SerializeField] 
    private
    GameObject _excaliberParticles;

    [SerializeField]
    public TMP_Text ProgressText;

    // Start is called before the first frame update
    void Awake()
    {
        GameManager = GameObject.Find("Game Manager").GetComponent<GameBehaviour>();
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.gameObject);
            Debug.Log("Excaliber Collected!");
            //GameManager.Items += 1;
            ProgressText.text = "Quest Complete!";

            _collectExcaliber.Play();
            _questCompleteMusic.Play();

            Instantiate(_excaliberParticles, gameObject.transform.position, Quaternion.identity);

        }


    }
}
