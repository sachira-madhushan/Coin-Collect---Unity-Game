using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Private Variables
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigi;
    private int _jumpCount = 2;
    [SerializeField]
    private GameObject Knife;
    [SerializeField]
    private GameManager gameManager;
    #endregion
    public float playerSpeed = 5, playerJumpSpeed = 10;
    public GameObject startPosition;
    private bool isRunning;
    void Start()
    {
        Knife.SetActive(false);
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigi = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {

        float moveInput = Input.GetAxis("Horizontal");

        if (moveInput < 0.1 && moveInput > -0.1)
        {

            _animator.SetBool("isRunning", false);
        }

        else
        {

            Knife.SetActive(false);
            _animator.SetBool("isRunning", true);
        }

        if (moveInput < -0.1)
        {
            isRunning = true;
            _rigi.velocity = new Vector2(moveInput * playerSpeed, -20*playerSpeed*Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (moveInput > 0.1)
        {
            isRunning = true;
            _rigi.velocity = new Vector2(moveInput * playerSpeed, -20* playerSpeed*Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        else
        {
            isRunning = false;
        }

        if (Input.GetKeyDown(KeyCode.W) && !(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && _jumpCount > 0 && !isRunning)
        {
            Knife.SetActive(false);
            _animator.SetBool("jump", true);
            _rigi.velocity = Vector2.up * playerJumpSpeed;
            _jumpCount--;
        }
        else
        {
            _animator.SetBool("jump", false);
        }
        if (_jumpCount != 2)
        {

        }
        print(_jumpCount);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Knife.SetActive(true);
            _animator.SetTrigger("attack");
        }

       

        if (transform.position.y < -6)
        {
            transform.position = startPosition.transform.position;
        }




    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Flatform")
        {
            print("colided");
            _jumpCount = 2;
        }
        if (collision.gameObject.tag == "Coin")
        {
            gameManager.UpdateCoins();
            Destroy(collision.gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Missile")
        {
            transform.position = startPosition.transform.position;
            Destroy(collision.gameObject);
        }
    }
}
