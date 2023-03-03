using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCoin : MonoBehaviour
{
    public GameBehaviour GameManager;
    public GameObject coin;
    public AudioSource collectCoins;
    public ParticleSystem particleSystem;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("Game Manager").GetComponent<GameBehaviour>();
        coin = GameObject.FindWithTag("Coin");
        collectCoins = GameObject.Find("SfxCollectCoins").GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(this.transform.gameObject);
            Debug.Log("Coin Collected!");
            GameManager.Credits += 10;
            collectCoins.Play();
            Instantiate(particleSystem, gameObject.transform.position, Quaternion.identity);
        }


    }
}
