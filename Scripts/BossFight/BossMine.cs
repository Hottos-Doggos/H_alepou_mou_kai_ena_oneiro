using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMine : MonoBehaviour
{
    public GameObject explosion; //μεταβλητή για δημιουργία έκρηξης

    //χτυπάει τον παίχτη μόλις πλησιάσει πολύ
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            Explode();
            PlayerHealthController.instance.DealDamage();
        }
    }

    //δημιουργεί έκρηξη
    public void Explode(){
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
        AudioManager.instance.PlaySFX(1);
    }
}
