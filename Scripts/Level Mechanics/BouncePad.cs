using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{

    private Animator anim;      //μεταβλητή για animation

    public float bounceForce;   //μεταβλητή για την όθηση του παίχτη

    //καλείται στο πρώτο frame
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    //εκτοξεύει τον παίχτη μόλις τον αγγίξει και παίζει ένα animation
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            PlayerController.instance.rb2d.velocity = new Vector2( PlayerController.instance.rb2d.velocity.x, bounceForce);
            anim.SetTrigger("Bounce");
            AudioManager.instance.PlaySFX(12);
        }
    }
}
