using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    public float moveForce = 9f;
    [SerializeField]
    public float jumpForce = 11f;

    private float movementX;
    
    private Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    private bool isGrounded = true;
    private string GROUND_TAG = "Ground";

    private string ENEMY_TAG = "Enemy";

    private bool mFacingRight = true;

    public GameObject deathEffect;

    [SerializeField]
    private AudioSource jumpSoundEffect;

    [SerializeField]
    private AudioSource deathSound;

    [SerializeField]
    private Canvas message;

    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();
        FlipPlayer();
        AnimatePlayer();
        PlayerJump();

        //set the y velocity in the animator
        anim.SetFloat("yVelocity", myBody.velocity.y);
    }

    void PlayerMoveKeyboard()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        transform.position += new Vector3(movementX, 0f, 0f)* Time.deltaTime * moveForce;
    }
    void FlipPlayer()
    {
        if(movementX>0 && !mFacingRight) //rights side 
        {
            Flip();
        }
        else if(movementX<0 && mFacingRight) //left side
        {
            Flip();
        }
    }

    void AnimatePlayer()
    {
        if(movementX>0) //rights side 
        {
             anim.SetBool(WALK_ANIMATION,true);
        }
        else if(movementX<0) //left side
        {
             anim.SetBool(WALK_ANIMATION,true);
        }
        else
        {
            anim.SetBool(WALK_ANIMATION,false);
        }
    }

    private void Flip()
    {
        mFacingRight = !mFacingRight;
        transform.Rotate(0f, 180f, 0f);
    }
    
    void PlayerJump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            myBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetBool("Jumping", true);
            jumpSoundEffect.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true; 
            //as long as we are grounded the jump bool is disabled
            anim.SetBool("Jumping", !isGrounded);
        }
        if(collision.gameObject.CompareTag(ENEMY_TAG))
        {
            deathSound.Play();
            FindObjectOfType<MonsterSpawner>().run = false;
            Instantiate(deathEffect, transform.position , Quaternion.identity);
            Destroy(gameObject);
            Destroy(FindObjectOfType<MonsterSpawner>().spawnedMonster);
            message.gameObject.SetActive(true);
        }
    }
}
