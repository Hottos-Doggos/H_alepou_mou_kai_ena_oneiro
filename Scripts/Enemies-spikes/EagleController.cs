using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleController : MonoBehaviour
{
    public static EagleController instance;

    //μεταβλητές κίνησης
    public float moveSpeed;
    public float moveTime, waitTime;
    float moveCount, waitCount;
    public Transform topPoint, bottomPoint;
    public SpriteRenderer sr;
    bool movingTop;
    Rigidbody2D rb2d;


    //καλείται πριν το πρώτο frame
    private void Awake() {
        instance = this;
    }

    //καλείται στο πρώτο frame
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        topPoint.parent = null;
        bottomPoint.parent = null;

        movingTop = true;

        moveCount = moveTime;
    }

    //καλείται μια φορά κάθε frame
    void Update()
    {
        Move();
    }

    //κίνηση του γερακιού
    private void Move(){
        if(moveCount > 0){
            moveCount -= Time.deltaTime;

            if(movingTop){
                rb2d.velocity = new Vector2(rb2d.velocity.x, moveSpeed);

                if(transform.position.y > topPoint.position.y){
                    movingTop = false;
                }
            }else {
                rb2d.velocity = new Vector2(rb2d.velocity.x, -moveSpeed);

                if(transform.position.y < bottomPoint.position.y){
                    movingTop = true;
                }
            }

            if(moveCount <= 0){
                waitCount = Random.Range(waitTime * 0.7f, waitTime * 1.2f);
            }

        }else if(waitCount > 0){
            waitCount -= Time.deltaTime;
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);

            if(waitCount <= 0){
                moveCount = Random.Range(moveTime * 0.9f, moveTime * 1.2f);
            }
        }
    }
}
