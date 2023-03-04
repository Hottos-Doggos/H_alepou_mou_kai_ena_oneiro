using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    //μεταβλητές ελέγχου ήχου
    public AudioSource[] soundEffects;
    public AudioSource bgMusic, levelEndMusic, bossMusic;


    //καλείται πριν το πρώτο frame
    private void Awake() {
        instance = this;
    }


    //παίζει ηχητικά εφέ
    public void PlaySFX(int soundToPlay){
        soundEffects[soundToPlay].Stop();

        soundEffects[soundToPlay].pitch = Random.Range(0.90f, 1.20f);

        soundEffects[soundToPlay].Play();
    }

    //αλλάζει την μουσική μόλις τελειώσεις το επίπεδο
    public void PlayLevelVictory(){
        bgMusic.Stop();
        levelEndMusic.Play();
    }

    //αλλάζει την μουσική μόλις αρχίσει η τελική μάχη
    public void PlayBossMusic(){
        bgMusic.Stop();
        bossMusic.Play();
    }

    //επιστρέφει στην κανονική μουσική μόλις τελειώσει η τελική μάχη
    public void StopBossMusic(){
        bgMusic.Play();
        bossMusic.Stop();
    }
}
