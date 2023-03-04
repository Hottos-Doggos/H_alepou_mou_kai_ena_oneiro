using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    //μεταβλητές για να ταυτοποιήσουμε το αντικείμενο
    public bool isGem, isHeal;
    bool isCollected;

    //μεταβλητές για εμφάνιση effect
    public GameObject pickupEffect;

    //μάζεμα του αντικειμένου μόλις το αγγίξει ο παίχτης
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player") && !isCollected){
            if(isGem){
                LevelManager.instance.gemsCollected++;
                isCollected = true;
                AudioManager.instance.PlaySFX(6);
                
                Destroy(gameObject);
                Instantiate(pickupEffect, transform.position, transform.rotation);

                UIController.instance.UpdateGemDisplay();
            }

            if(isHeal){
                if(PlayerHealthController.instance.currentHealth != PlayerHealthController.instance.maxHealth){
                    PlayerHealthController.instance.HealPlayer();
                    isCollected = true;
                    AudioManager.instance.PlaySFX(7);

                    Destroy(gameObject);
                    Instantiate(pickupEffect, transform.position, transform.rotation);
                }
            }
        }
    }
}
