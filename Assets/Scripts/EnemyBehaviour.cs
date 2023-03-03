using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField]
    public Transform PlayerLocation;

    [SerializeField]
    public Transform PatrolRoute;

    [SerializeField]
    public List<Transform> Locations;

    [SerializeField]
    private int _locationIndex = 0;

    [SerializeField]
    private NavMeshAgent _agent;

    [SerializeField]
    public int _currentHealth = 100;

    [SerializeField]
    public ParticleSystem EnemyExplode;

    [SerializeField]
    public Transform Player;

    [SerializeField]
    public HealthBar healthBar;

    [SerializeField]
    public GameObject powerUp;
    public int EnemyLives
    {
        get { return _currentHealth; }
        
        set
        {
            _currentHealth = value;

            if (_currentHealth <=0)
            { Destroy(this.gameObject);
                Instantiate(EnemyExplode, gameObject.transform.position, Quaternion.identity);
                Instantiate(powerUp, gameObject.transform.position, Quaternion.identity);
                Debug.Log("Enemy Down!");
            }

            else
            {

                healthBar.SetHealth(_currentHealth);
            }
                
        }
    }

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player").transform;
        healthBar.SetMaxHealth(_currentHealth);
        Debug.Log("Enemy Health set to" + _currentHealth);

        //EnemyExplode = GameObject.Find("EnemyExplode");
        //Instantiate(EnemyExplode, gameObject.transform.position, Quaternion.identity);
        InitializePatrolRoute();
        MoveToNextPatrolLocation();

    }
    void Update()
    {
        if(_agent.remainingDistance <0.2f && !_agent.pathPending)
        {
            MoveToNextPatrolLocation();
        }
    }

    private void LateUpdate()
    {
        
    }
    void InitializePatrolRoute()
    {
        foreach (Transform child in PatrolRoute)
        {
            Locations.Add(child);
        }
    }
    
    void MoveToNextPatrolLocation()
    {
        if (Locations.Count == 0)
            return;

        _agent.destination = Locations[_locationIndex].position;

        _locationIndex = (_locationIndex +1) % Locations.Count;

    }
      
    //isTrigger must be ticked in the inspector to allow player to enter the collider zone.
    void OnTriggerStay(Collider other)
    {
        if (_agent != null)
        {
            if (other.name == "Player")
            {
                _agent.destination = Player.position;
                Debug.Log("Player detected - attack!");
            }
        }
          
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            EnemyLives -= 10;
            Debug.Log("Critical hit!");
            
        }

        if (other.gameObject.CompareTag("PlayerSword"))
        {
            EnemyLives -= 5;
            Debug.Log("Sword hit!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player out of range, resume patrol");
        }
    }
    
}
    
