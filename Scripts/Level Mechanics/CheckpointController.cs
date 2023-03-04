using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public static CheckpointController instance;
    private Checkpoint[] checkpoints;

    //μεταβλητές για αποθήκευση θέσης του παίχτη
    public Vector3 spawnPoint;

    //καλείται πριν το πρώτο frame
    private void Awake() {
        instance = this;
    }

    //καλείται στο πρώτο frame
    void Start()
    {
        checkpoints = FindObjectsOfType<Checkpoint>();
        
        spawnPoint = PlayerController.instance.transform.position;
    }

    //κάνει το checkpoint να μην λειτουργεί πια
    public void DeactivateCheckpoint(){
        for(int i = 0; i < checkpoints.Length; i++){
            checkpoints[i].ResetCheckpoint();
        }
    }

    //Ορίζει την θέση που θα spawnάρει ο παίχτης
    public void SetSpawnPoint(Vector3 newSpawnPoint){
        spawnPoint = newSpawnPoint;
    }

}
