using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    //μεταβλητές για άλλαγμα sprite της πινακίδας
    public SpriteRenderer sr;
    public Sprite cpOn, cpOff;
    
    //καλείται στο πρώτο frame
    void Start()
    {
        
    }

    //καλείται μια φορά κάθε frame
    void Update()
    {
        
    }

    //αλλάζει sprite μόλις ακουμπηθεί από τον παίχτη
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Player")){
            CheckpointController.instance.DeactivateCheckpoint();
            sr.sprite = cpOn;

            CheckpointController.instance.SetSpawnPoint(transform.position);
        }
    }

    //αλλάζει το sprite της πινακίδας σε off
    public void ResetCheckpoint(){
        sr.sprite = cpOff;
    }
}
