using UnityEngine;
public class CircleFormation : MonoBehaviour
{
    
    //Game object prefab to be used in circle formation
    public GameObject prefab;

    //Set number of objects as well as radius of the circle
    public int numberOfObjects = 20;
    public float radius = 5f;

    //Sfx when circle formation is triggered
    public AudioSource audioSource;

    //Boss Battle Logic
    private bool trapActive; 
    private bool isTrapped;
    private bool bossDefeated;
    private bool bossSpawned;

    //Gameobjects
    public GameObject Player;
    public GameObject Trap;
    public GameObject enemyPrefab;
    private GameObject Boss;
    public GameObject bossSpawnPoint;
    public GameObject trapCollider;

    private void Awake()
    {
        trapActive = true;
        isTrapped = false;
        bossDefeated = false;


    }

    private void Start()
    {
        //Find and create a reference to the player in the scene
        Player = GameObject.Find("Player");
        Trap = GameObject.Find("TrapTrigger");
        enemyPrefab = GameObject.Find("SkeletonBoss");
        
    }

    private void Update()
    {
        if (isTrapped)
        {
            //play battle music
            Debug.Log("Boss Battle Music");
        }

        if(bossDefeated)
        {
            //Destroy Stone Circle
            //Play win condition music
            Debug.Log("Boss Defeated Music");
            Destroy(Trap);
        }

        if(!Boss && bossSpawned && trapActive)
        {
            bossDefeated = true;
            Debug.Log("BOSS DEFEATED");
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //Detect if player collides with the trap collider
        if (other.CompareTag("Player"))
        {
            //Call trap method to create the circle trap
            trap();
            isTrapped = true;

            //Deactivate the box collider to avoid extra triggers
            deactivateTrap();

            //
            attack();

        }
    }
    void trap()
    {

        //create new game object to hold instantiated stone circle.
        // how?
        for (int i = 0; i < numberOfObjects; i++)
        {

            float angle = i * Mathf.PI * 2 / numberOfObjects;
            float x = Mathf.Cos(angle) * radius;
            float z = Mathf.Sin(angle) * radius;
            Vector3 pos = transform.position + new Vector3(x, 0, z);
            float angleDegrees = -angle * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.Euler(0, angleDegrees, 0);
            Instantiate(prefab, pos, rot); //setparent
        }

        //Play Sfx
        audioSource.Play();

    }
    void attack()
    {
        //Call spawnBoss method
        spawnBoss();
    }

     void spawnBoss()
    {
        //Instantiate the Boss Enemy from the boss spawn point transform
        Instantiate(enemyPrefab, bossSpawnPoint.transform.position, bossSpawnPoint.transform.rotation);

        bossSpawned = true;
        bossDefeated = false;


        GameObject Boss = GameObject.Find("SkeletonBoss");
    }

    void deactivateTrap()
    {
        GetComponent<BoxCollider>().enabled = (false);
    }
}