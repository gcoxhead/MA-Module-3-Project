using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHealth : MonoBehaviour
{
    public GameBehaviour GameManager;
    public GameObject health;

    // Start is called before the first frame update
    private void Start()
    {
       GameManager = GameObject.Find("Game Manager").GetComponent<GameBehaviour>();
       health = GameObject.FindWithTag("Health");
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player" )
        {
            Destroy(this.transform.gameObject);
            Debug.Log("Health Restored!");
            GameManager.HP += 1;
        }

    }
}
