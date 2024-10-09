using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public float fallingThreshold = -5f;
    private bool isJumping = false;
    private bool isFacingRight = true;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    public Animator animator;
    static public bool canMove;
    static public int health = 3;
    static public int score = 0;
    public TMP_Text scoreBar;
    public GameObject player;
    private int i;
    public GameObject QCanvas;
    public GameObject[] hearts;
    public AudioSource[] attacks;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        rb.freezeRotation = true;
        canMove = true;
        animator.SetBool("Death", false);
        health = 3;
        score = 0;
    }

    private void Update()
    {
        // Movement
        float moveX = Input.GetAxis("Horizontal");
        if (canMove)
        {
            // Flipping the character's sprite
            if (moveX > 0 && !isFacingRight)
            {
                FlipCharacter();
            }
            else if (moveX < 0 && isFacingRight)
            {
                FlipCharacter();
            }

            // Triggering animation based on movement
            animator.SetBool("Running", moveX != 0f);

            // Jumping
            if (Input.GetKeyDown(KeyCode.W) && !isJumping)
            {
                animator.SetBool("Jumping", true);
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                isJumping = true;
            }
        }
        else
        {
            animator.SetBool("Running", false);
        }
        // Check if the character is falling
        bool isFalling = rb.velocity.y < fallingThreshold;
        animator.SetBool("Falling", isFalling);

        scoreBar.text = score.ToString();

        if (health <= 0)
        {
            QCanvas.SetActive(false);
            canMove = false;
            animator.Play("DeathAnimation");
            StartCoroutine(deathroutine());
        }

        //Health Update
        if (health == 3)
        {
            hearts[0].SetActive(true);
            hearts[1].SetActive(true);
            hearts[2].SetActive(true);
        }
        else if (health == 2)
        {
            hearts[0].SetActive(true);
            hearts[1].SetActive(true);
            hearts[2].SetActive(false);
        }
        else if (health == 1)
        {
            hearts[0].SetActive(true);
            hearts[1].SetActive(false);
            hearts[2].SetActive(false);
        }
        else if (health <= 0)
        {
            hearts[0].SetActive(false);
            hearts[1].SetActive(false);
            hearts[2].SetActive(false);
        }
  
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        if (canMove)
        {
            // Movement
            
            rb.velocity = new Vector2(moveX * moveSpeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(moveX * 0, rb.velocity.y);
            // Triggering animation based on movement
            animator.SetBool("Running", false);
        }
     }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player has landed on the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("Jumping", false);
            animator.SetBool("Falling", false);
            isJumping = false;
        }
    }

    private void FlipCharacter()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private IEnumerator deathroutine()
    {
        
        yield return new WaitForSecondsRealtime(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void attack()
    {
        i = Random.Range(0, 3);
        Debug.Log(i);
        if (i == 0)
        {
            player.GetComponent<Animator>().Play("DamageAnimation");
            attacks[i].Play();
        }
        else if (i == 1)
        {
            player.GetComponent<Animator>().Play("DamageAnimation1");
        }
        else
        {
            player.GetComponent<Animator>().Play("DamageAnimation2");
        }
        attacks[i].Play();
 
    }

    public void takeDamage()
    {
        player.GetComponent<Animator>().Play("TakeDamage");
        health--;
    }


}
