using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{

    //μεταβλητές για λειτουργία μοχλού
    public GameObject objectToSwitch;
    SpriteRenderer sr;
    public Sprite downSprite;
    public Sprite upSprite;
    bool hasSwitched;
    

    //καλείται στο πρώτο frame
    void Start() {
        sr = GetComponent<SpriteRenderer>();
    }

    //καλείται μια φορά κάθε frame
    void Update(){
        CheckIfPlayerDead();
    }

    //ανοίγει την πόρτα 
    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && !hasSwitched){
            objectToSwitch.SetActive(false);
            
            sr.sprite = downSprite;
            hasSwitched = true;
        }
    }

    //Αν ο παίχτης πεθάνει, οι πόρτες ξανά κλείνουν
    void CheckIfPlayerDead(){
        if(!PlayerController.instance.gameObject.activeSelf){
            objectToSwitch.SetActive(true);
            
            sr.sprite = upSprite;
            hasSwitched = false;
        }
    }

}
