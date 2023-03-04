using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivator : MonoBehaviour
{
    public GameObject bossBattle; //μεταβλητή αναφοράς ενεργοποιήσης της τελικής μάχης

    //ξεκινάει την τελική μάχη μόλις ο παίχτης αγγίξει την περιοχή
    private void OnTriggerEnter2D(Collider2D other){
        if(other.tag == "Player"){
            bossBattle.gameObject.SetActive(true);
            gameObject.SetActive(false);

            AudioManager.instance.PlayBossMusic();
        }
    }
}
