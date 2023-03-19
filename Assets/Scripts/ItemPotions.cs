using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPotions : MonoBehaviour
{
    [SerializeField]
    private GameBehaviour GameManager;
    
    [SerializeField]
    private GameObject _potion;

    [SerializeField] 
    private AudioSource _collectPotion;
    
    [SerializeField] 
    private
    GameObject _potionParticles;

    // Start is called before the first frame update
    void Awake()
    {
        GameManager = GameObject.Find("Game Manager").GetComponent<GameBehaviour>();
        _potion = GameObject.FindWithTag("Potion");
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.gameObject);
            Debug.Log("Potion Collected!");
            GameManager.Items += 1;
            //_potionParticles.SetActive(true);
            _collectPotion.Play();
            Instantiate(_potionParticles, gameObject.transform.position, Quaternion.identity);

        }


    }
}
