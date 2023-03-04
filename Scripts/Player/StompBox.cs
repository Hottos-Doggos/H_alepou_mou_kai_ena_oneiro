using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompBox : MonoBehaviour
{
    //μεταβλητές για να έχει πιθανότητες ο εχθρός να ρίξει κεράσι
    public GameObject deathEffect;
    public GameObject collectible;
    [Range(0, 100)]public float chanceToDrop;


    //σκοτώνει τον  εχθρό όταν τον ακουμπήσει
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Frog"){
            Destroy(other.transform.parent.gameObject);
            
            float dropSelect = Random.Range(0, 100);
            if(dropSelect <= chanceToDrop){
                Instantiate(collectible, other.transform.position, other.transform.rotation);
            }
        }
        if(other.tag == "Eagle"){
            other.transform.parent.gameObject.SetActive(false);
        }
        
        if(other.tag == "Frog" || other.tag == "Eagle"){
            Instantiate(deathEffect, other.transform.position, other.transform.rotation);
            PlayerController.instance.Bounce();

            AudioManager.instance.PlaySFX(3);
        }
    }
}
