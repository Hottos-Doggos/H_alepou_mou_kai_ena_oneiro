using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    //χτυπάει τον παίχτη μόλις τον ακουμπήσει
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player")
            PlayerHealthController.instance.DealDamage();
    }
}
