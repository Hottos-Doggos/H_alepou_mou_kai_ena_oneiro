using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    //μεταβλητές κίνησης
    public float moveSpeed;
    public float moveTime, waitTime;
    float moveCount, waitCount;
    public Transform leftPoint, rightPoint;
    public SpriteRenderer sr;
    bool movingRight;
    Rigidbody2D rb2d;
    Animator anim;


    //καλείται στο πρώτο frame
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;

        moveCount = moveTime;
    }

    //καλείται μια φορά κάθε frame
    void Update()
    {
        Move();
    }

    //κίνηση του βατράχου
    private void Move(){
        if(moveCount > 0){
            moveCount -= Time.deltaTime;

            if(movingRight){
                rb2d.velocity = new Vector2(moveSpeed, rb2d.velocity.y);
                sr.flipX = true;

                if(transform.position.x > rightPoint.position.x){
                    movingRight = false;
                }
            }else {
                rb2d.velocity = new Vector2(-moveSpeed, rb2d.velocity.y);
                sr.flipX = false;

                if(transform.position.x < leftPoint.position.x){
                    movingRight = true;
                }
            }

            if(moveCount <= 0){
                waitCount = Random.Range(waitTime * 0.7f, waitTime * 1.2f);
            }

        //animations του βατράχου
        anim.SetBool("isMoving", true);
        }else if(waitCount > 0){
            waitCount -= Time.deltaTime;
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);

            if(waitCount <= 0){
                moveCount = Random.Range(moveTime * 0.9f, moveTime * 1.2f);;
            }
            anim.SetBool("isMoving", false);
        }
    }
}
