using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    //καλεί να τελειώσει το επίπεδο μόλις αγκίξει ο παίχτης την σημαία
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            LevelManager.instance.EndLevel();
        }
    }
}
