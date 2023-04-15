using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float MoveSpeed = 10f;
    public float RotateSpeed = 75f;

    private float _vInput;
    private float _hInput;
    private Rigidbody _rb;

    public float JumpVelocity = 5f;
    private bool _isJumping;

    public float DistanceToGround = 0.1f;
    public LayerMask GroundLayer;
    private CapsuleCollider _col;

    public GameObject Bullet;
    public float BulletSpeed = 100f;
    private bool _isShooting;
    bool isHit = false;

    private GameBehaviour _gameManager;

    [SerializeField]
    Animator animator;
  
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _col = GetComponent<CapsuleCollider>();
        _gameManager = GameObject.Find("Game Manager").GetComponent<GameBehaviour>();
        //Debug.Log("Game object reference created");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        _vInput = Input.GetAxis("Vertical") * MoveSpeed;
        _hInput = Input.GetAxis("Horizontal") * RotateSpeed;
        _isJumping |= Input.GetKeyDown(KeyCode.J);
        _isShooting |= Input.GetKeyDown(KeyCode.Space);

        if (IsGrounded())
        {
            Debug.Log("Grounded");
        }
        /*
        this.transform.Translate(Vector3.forward * _vInput * Time.deltaTime);
        this.transform.Rotate(Vector3.up * _hInput * Time.deltaTime);
        */
        

    }

    void FixedUpdate()
    {
        //if (_isJumping)
        //{
        //  _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);
        //}

        Vector3 rotation = Vector3.up * _hInput;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);

        _rb.MovePosition(this.transform.position + this.transform.forward * _vInput * Time.fixedDeltaTime);
        _rb.MoveRotation(_rb.rotation * angleRot);

        if (IsGrounded() && _isJumping)
        {
            _rb.AddForce(Vector3.up * JumpVelocity, ForceMode.Impulse);

        }
        _isJumping = false;

        if (_isShooting)
        {
            GameObject newBullet = Instantiate(Bullet, this.transform.position + new Vector3(1, 1, 1), this.transform.rotation);

            //Rigidbody BulletRB = newBullet.GetComponent<Rigidbody>(); //transform

            //BulletRB.velocity = this.transform.forward * BulletSpeed;
        }
        _isShooting = false;

    }
        private bool IsGrounded()
        {
            Vector3 capsuleBottom = new Vector3(_col.bounds.center.x, 
                _col.bounds.min.y, _col.bounds.center.z);

            bool grounded = Physics.CheckCapsule(_col.bounds.center, 
                capsuleBottom, DistanceToGround, GroundLayer, QueryTriggerInteraction.Ignore);
        
        return grounded;
        }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemySword"))
        {
            _gameManager.HP -= 4;

            Debug.Log("Enemy Damage Taken -4");
            if(!isHit)
            animator.SetBool("takenDamage", true);
            Debug.Log("Damage Animation should play");
            isHit = true;
        }

        if (other.gameObject.CompareTag("Spike"))
        {
            _gameManager.HP -= 6;
            Debug.Log("That was sharp...-6 damage");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("EnemySword")&& isHit)
        {

            isHit = false;
            animator.SetBool("takenDamage", false);
            Debug.Log("Damage Animation should play");
            
        }

        if (other.gameObject.CompareTag("Spike"))
        {
            _gameManager.HP -= 6;
            Debug.Log("That was sharp...-6 damage");
        }
    }


}
