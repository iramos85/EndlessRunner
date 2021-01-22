using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float distanceTraveled;
    public int collectedCoins;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float jumpForce = 5;
    [SerializeField] Transform raycastOrigin;
    [SerializeField] bool isGrounded;    
    [SerializeField] Animator anim;
    [SerializeField] UIController uIController;
    [SerializeField] bool airJump;
    [SerializeField] bool shieldActivated;
    [SerializeField] GameObject shield;
    [SerializeField] SFXManager sfxManager;
    
    bool playerIsFalling;
    bool jump;
    float lastYPos;

    private void Start()
    {
        lastYPos = transform.position.y;

    }

    void Update()
    {
        //distanceTraveled = distanceTraveled + Time.deltaTime;
        distanceTraveled += Time.deltaTime;
        CheckForInput();
        FallingAnim();
    }

    void FixedUpdate()
    {
        CheckForGrounded();
        JumpMove();
    }


    void FallingAnim()
    {
        if (transform.position.y < lastYPos)
        {
            anim.SetBool("Falling", true);
            playerIsFalling = true;
        }
        else
        {
            anim.SetBool("Falling", false);
            playerIsFalling = false;
        }

        lastYPos = transform.position.y;
    }

    void JumpMove()
    {
        if (jump == true)
        {
            jump = false;
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    void CheckForInput()
    {
        if (isGrounded == true || airJump == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if(airJump == true && isGrounded == false)
                {
                    airJump = false;
                    sfxManager.PlaySFX("DoubleJump");
                }
                else
                {
                    sfxManager.PlaySFX("Jump");
                }
                jump = true;
                anim.SetTrigger("Jump");
            }
        }
    }

    void CheckForGrounded()
    {
            RaycastHit2D hit = Physics2D.Raycast(raycastOrigin.position, Vector2.down);

            if (hit.collider != null)
            {
                if (hit.distance < 0.1f)
                {
                    isGrounded = true;
                    anim.SetBool("IsGrounded", true);
                if(playerIsFalling == true)
                {
                    sfxManager.PlaySFX("Land");
                }
            } else
            {
                isGrounded = false;
            }
              
                //Debug.Log(hit.transform.name);
                Debug.DrawRay(raycastOrigin.position, Vector2.down, Color.green);
            }
        else
        {
            isGrounded = false;
            anim.SetBool("IsGrounded", false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Obstacle"))
        {
            if (shieldActivated == true)
            {
                shield.SetActive(false);
                sfxManager.PlaySFX("ShieldBreak");
                Destroy(collision.gameObject);
            }
            else
            {
                sfxManager.PlaySFX("GameOverHit");
                uIController.ShowGameOverScreen();
            }
        }

        if (collision.transform.CompareTag("DeathBox"))
        {
            uIController.ShowGameOverScreen();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectable"))
        {
            collectedCoins++;
            sfxManager.PlaySFX("Coin");
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("AirJump"))
        {
            airJump = true;
            sfxManager.PlaySFX("PowerupDoubleJump");
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("ShieldPowerUp"))
        {
            shield.SetActive(true);
            sfxManager.PlaySFX("PowerupShield");
            shieldActivated = true;
            Destroy(collision.gameObject);
        }
    }

}
       