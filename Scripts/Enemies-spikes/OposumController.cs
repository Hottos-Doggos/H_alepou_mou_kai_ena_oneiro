using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OposumController : MonoBehaviour
{
    public static OposumController instance;

    //μεταβλητές κίνησης
    public float moveSpeed;
    public Transform leftPoint, rightPoint;
    public SpriteRenderer sr;
    bool movingRight;
    Rigidbody2D rb2d;


    //καλείται πριν το πρώτο frame
    private void Awake() {
        instance = this;
    }

    //καλείται στο πρώτο frame
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;
    }

    //καλείται μια φορά κάθε frame
    void Update()
    {
        Move();
    }

    //κίνηση του πόσουμ
    private void Move(){

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
    }
}
