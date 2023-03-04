using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController instance;
    
    //μεταβλητές της ζωής του παίχτη
    public int currentHealth, maxHealth;
    public float invincibleLength;
    float invincibleCounter;
    SpriteRenderer sr;

    public GameObject deathEffect; //μεταβλητή για εμφάνιση effect όταν ο παίχτης θα πεθάνει


    //καλείται πριν το πρώτο frame
    void Awake() {
        instance = this;
    }

    //καλείται στο πρώτο frame
    void Start()
    {
        currentHealth = maxHealth;
        sr = GetComponent<SpriteRenderer>();
    }

    //καλείται μια φορά κάθε frame
    void Update()
    {
        if(invincibleCounter >= 0){
            invincibleCounter -= Time.deltaTime;
            
            if(invincibleCounter <= 0){
                sr.color = new Color(sr.color.r, sr.color.g, sr.color.b);
            }
        }
    }

    //χτύπημα του παίχτη
    public void DealDamage(){
        if(invincibleCounter <= 0){
            currentHealth--;
            
            if(currentHealth <= 0){
                currentHealth = 0;
                AudioManager.instance.PlaySFX(8);
                
                Instantiate(deathEffect, transform.position, transform.rotation);
                

                LevelManager.instance.RespawnPlayer();

                }else{
                    invincibleCounter = invincibleLength;
                    sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0.5f);

                    PlayerController.instance.KnockBack();
                    }
                
            UIController.instance.UpdateHealthDisplay();
        }
    }

    //δίνει στον παίχτη ζωή
    public void HealPlayer(){
        currentHealth++;
        if(currentHealth > maxHealth){
            currentHealth = maxHealth;
        }

        UIController.instance.UpdateHealthDisplay();
    }
}
