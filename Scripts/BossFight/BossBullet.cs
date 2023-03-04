using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public int speed;

    //καλείται μια φορά κάθε frame
    void Update()
    {
        Move();
    }

    //κάνει την σφαίρα να κουνιέται
    void Move(){
        transform.position += new Vector3(-speed * transform.localScale.x * Time.deltaTime, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Player" || other.tag == "Player's Legs"){
            PlayerHealthController.instance.DealDamage();
        }

        Destroy(gameObject);
    }
}
