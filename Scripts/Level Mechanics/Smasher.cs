using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smasher : MonoBehaviour
{
    //μεταβλητές κίνησης... πως το λες τώρα αυτό στα Ελληνικά? Ξέρω γω...? χτυπητή? λιοματάρχη? Εσύ διάλεξε.
    public Transform smasher, target;
    Vector3 startPoint;
    public int smashSpeed, resetSpeed;
    public float waitAfterSmash;
    float waitCounter;
    bool smashing, resetting, audioPlays;


    //καλείται στο πρώτο frame
    void Start() {
        startPoint = smasher.position;
    }

    //καλείται μια φορά κάθε frame
    void Update() {
        Smash();
    }

    //κοπανάει κάτω μόλις πλησιάσει ο παίχτης
    private void Smash(){
        if(!smashing && !resetting){
            if(Vector3.Distance(target.position, PlayerController.instance.transform.position) < 2f){
                smashing = true;
                waitCounter = waitAfterSmash;
            }
        }
        
        if(smashing){
            smasher.position = Vector3.MoveTowards(smasher.position, target.position, smashSpeed * Time.deltaTime);

            if(smasher.position == target.position){
                if(!audioPlays){
                    audioPlays = true;
                    AudioManager.instance.PlaySFX(9);
                }
                
                waitCounter -= Time.deltaTime;
                
                if(waitCounter <= 0){
                    smashing = false;
                    resetting = true;
                    audioPlays = false;
                }
            }
        }

        if(resetting){
            smasher.position = Vector3.MoveTowards(smasher.position, startPoint, resetSpeed * Time.deltaTime);

            if(smasher.position == startPoint){
                resetting = false;
            }
        }
    }
}
