using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFightController : MonoBehaviour
{
    //κατάσταση του εχθρού (παρακαλώ πολύ δεν θα ήθελα κανένα σχόλιο (λογοπαίγνιο) για την ονομασία της τελευταίας κατάστασης)
    public enum bossStates {shooting, hurt, moving, deadLolBadToBeYouLmaoFatherlessPlusRatioPlusNoBitchesPlusNoWinsPlusCryAboutIt};
    public bossStates currentState;

    //γενικές μεταβλητές
    public Transform boss;
    public Animator anim;
    
    //μεταβλητές κίνησης
    [Header("Κίνηση")]
    public int moveSpeed;
    public Transform leftPoint;
    public Transform rightPoint;
    bool isMovingRight;
    public GameObject mine;
    public Transform minePoint;
    public float timeBetweenMines;
    float mineCounter;

    //μεταβλητές επίθεσης
    [Header("Επίθεση")]
    public GameObject bullet;
    public Transform firePoint;
    public float timeBetweenShots;
    float shotCounter;

    //μεταβλητές χτυπήματος 
    [Header("Χτύπημα")]
    public float hurtTime;
    float hurtCounter;
    public GameObject hitBox;

    //μεταβλητές ζωής εχθρού
    [Header("Ζωή")]
    public int health;
    public GameObject explosion, winPlatform;
    bool isDefeated;
    public float shotSpeedUp;
    public float mineSpeedUp;


    //καλείται στο πρώτο frame
    void Start()
    {
        currentState = bossStates.shooting;
    }

    //καλείται μια φορά κάθε frame
    void Update()
    {
        SwitchState();
    }

    //αλλάζει την κατάσταση του εχθρού
    void SwitchState()
    {
        switch(currentState){
            case bossStates.shooting:

            shotCounter -= Time.deltaTime;

            if(shotCounter <= 0){
                shotCounter = timeBetweenShots;

              var newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
              newBullet.transform.localScale = boss.localScale;
              AudioManager.instance.PlaySFX(1);
            }
            break;

            case bossStates.hurt:
            if(hurtCounter > 0){
                hurtCounter -= Time.deltaTime;
                if(hurtCounter <= 0){
                    currentState = bossStates.moving;

                    mineCounter = 0;

                    if(isDefeated){
                        boss.gameObject.SetActive(false);
                        Instantiate(explosion, boss.position, boss.rotation);

                        winPlatform.SetActive(true);
                        AudioManager.instance.StopBossMusic();

                        currentState = bossStates.deadLolBadToBeYouLmaoFatherlessPlusRatioPlusNoBitchesPlusNoWinsPlusCryAboutIt;
                    
                    }
                }
            }
            break;

            case bossStates.moving:
            if(isMovingRight){
                boss.position += new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
                if(boss.position.x > rightPoint.position.x){
                    boss.localScale = new Vector3(1, 1, 1);
                    
                    isMovingRight = false;
                    EndMoving();
                }
            
            }else 
            if(!isMovingRight){
                boss.position -= new Vector3(moveSpeed * Time.deltaTime, 0f, 0f);
                if(boss.position.x < leftPoint.position.x){
                    boss.localScale = new Vector3(-1, 1, 1);
                    
                    isMovingRight = true;
                    EndMoving();
                }
            }

            mineCounter -= Time.deltaTime;
            if(mineCounter <= 0){
                mineCounter = timeBetweenMines;
                Instantiate(mine, minePoint.position, minePoint.rotation);
            }

            break; 
        }
    }

    //χτυπάει τον εχθρό
    public void GetHit(){
        currentState = bossStates.hurt;
        hurtCounter = hurtTime;

        anim.SetTrigger("Hit");

        BossMine[] mines = FindObjectsOfType<BossMine>();
        if(mines.Length > 0){
            foreach(BossMine foundMine in mines){
                foundMine.Explode();
            }
        }

        health --;
        if(health <= 0){
            isDefeated = true;
        }else{
            timeBetweenShots /= shotSpeedUp;
            timeBetweenMines /= mineSpeedUp;
        }

    }

    //σταματάει να κουνιέται και ζητάει από τον εχθρό να πυροβολήσει
    void EndMoving(){
        currentState= bossStates.shooting;
        shotCounter = 0;
        anim.SetTrigger("StoppedMoving");
        hitBox.SetActive(true);
    }
}
