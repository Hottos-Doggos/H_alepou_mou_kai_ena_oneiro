using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillPlayer : MonoBehaviour
{   
    //array που περιέχει τους αετούς του επιπέδου
    public GameObject[] gameObjects;

    //μεταβλητές χρονόμετρου
    public float startingTimeRemaining;
    float timeRemaining;
    public bool timerIsRunning;
    public Text timeText;
    public GameObject deathEffect;

    public int restartedLevel; //μεταβλητή που χρησιμεύει στην επανέναρξη επιπέδου 


    //καλείται στο πρώτο frame
    void Start() {
        if(timerIsRunning){
            timeRemaining = startingTimeRemaining;
        } 
    }
    

    //καλείται μια φορά κάθε frame
    void Update()
    {
        EagleRelive();
        TimeBeforeDying();
    }
    
    //σκοτώνει απευθείας τον παίχτη μόλις τον ακουμπήσει
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            LevelManager.instance.RespawnPlayer();
        }
    }

    //επαναφέρει τους αετούς αν ο παίχτης πεθάνει
    private void EagleRelive()
    {
        if(!PlayerController.instance.gameObject.activeSelf){
            //EagleController.instance.gameObject.SetActive(true);
            foreach (GameObject eagle in gameObjects){
            eagle.SetActive(true);
            
            }
        }
    }

    //ξεκινάει αντίστροφη μέτρηση
    private void TimeBeforeDying(){
        if (timerIsRunning && !PlayerController.instance.stopInput)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timerIsRunning = false;

                PlayerController.instance.gameObject.SetActive(false);
                Instantiate(deathEffect, PlayerController.instance.transform.position, PlayerController.instance.transform.rotation);
                AudioManager.instance.PlaySFX(8);
                Invoke("DieAndRestart", 3f);
            }
        }
    }

    //εμφανίζει τον χρόνο
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    //κάνει επανέναρξη του επιπέδου
    void DieAndRestart(){
        LevelManager.instance.RestartLevel(restartedLevel);
    }
}
