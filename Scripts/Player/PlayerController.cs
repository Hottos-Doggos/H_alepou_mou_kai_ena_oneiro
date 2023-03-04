using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    //μεταβλητές κίνησης
    public float moveSpeed;
    public bool stopInput;
    public Rigidbody2D rb2d;

    //μεταβλητές πηδήματος
    public float jumpForce;
    public float bounceForce;
    bool isOnGround;
    public Transform isOnGroundCheckPoint;
    public LayerMask whatIsGround;
    bool canDoubleJump;

    //μεταβλητές για τα animations του παίχτη
    private Animator anim;
    private SpriteRenderer sr;

    //μεταβλητές για όταν χτυπιέται ο παίχτης
    public float knockBackLength, knockBackForce;
    float knockBackCounter;



    //καλείται πριν το πρώτο frame
    private void Awake() {
        instance = this;
    }

    //καλείται στο πρώτο frame
    void Start()
    {
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    //καλείται μια φορά κάθε frame
    void Update()
    {
        Move();
    }

    //κίνηση του παίχτη
    private void Move(){
        if(!PauseMenu.instance.isPaused && !stopInput){
            if(knockBackCounter <= 0){
                rb2d.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rb2d.velocity.y);

                if(rb2d.velocity.x < 0)
                    sr.flipX = true;
                else if(rb2d.velocity.x > 0)
                    sr.flipX = false;
        
                Jump();
            }else{
                knockBackCounter -= Time.deltaTime;
                if(!sr.flipX)
                    rb2d.velocity = new Vector2(-knockBackForce, rb2d.velocity.y);
                else
                    rb2d.velocity = new Vector2(knockBackForce, rb2d.velocity.y);
            }
        }else {
            isOnGround = true;
            if(!sr.flipX)
                rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
            else
                rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
        }

        //animations του παίχτη
        anim.SetFloat("moveSpeed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("isOnGround", isOnGround);
    }
    
    //πήδημα και διπλό πήδημα
    private void Jump(){
        isOnGround = Physics2D.OverlapCircle(isOnGroundCheckPoint.position, 0.2f, whatIsGround);
        
        if(isOnGround){
            canDoubleJump = true;
        }

        if(Input.GetButtonDown("Jump")){
            if(isOnGround){
                AudioManager.instance.PlaySFX(10);
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
            }else{
                if(canDoubleJump){
                    AudioManager.instance.PlaySFX(10);
                    rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                    canDoubleJump = false; 
                }
            }
        }
    }

    //κίνηση του παίχτη προς τα πίσω μόλις χτυπηθεί
    public void KnockBack(){
        AudioManager.instance.PlaySFX(9);
        knockBackCounter = knockBackLength;
        rb2d.velocity = new Vector2(0, knockBackForce);
        anim.SetTrigger("isHurt");
    }

    //εκτοξεύει τον παίχτη ψηλά
    public void Bounce(){
        rb2d.velocity = new Vector2(rb2d.velocity.x, bounceForce);
    }

    //δεσμεύει τον παίχτη να κουνιέται μαζί με την πλατφόρμα
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Platform"){
            transform.parent = other.transform;
        }
    }

    //ξεδεσμεύει τον παίχτη να κουνιέται μαζί με την πλατφόρμα
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Platform"){
            transform.parent = null;
        }
    } 

}
