using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float WaitToRespawn; //μεταβλητή για την διάρκεια μέχρι ο παίχτης να κάνει respawn 

    public int gemsCollected;   //μεταβλητή που μετράει την ποσότητα των διαμαντιών
    public float timeInLevel;   //μεταβλητή που μετράει πόση ώρα περνάει σε ένα επίπεδο

    public string levelToLoad;  //μεταβλητή για το επόμενο επίπεδο που θα φορτώσει

    //καλείται πριν το πρώτο frame
    private void Awake() {
        instance = this;
    }

    //καλείται στο πρώτο frame
    void Start()
    {
        timeInLevel = 0f;
    }

    //καλείται μια φορά κάθε frame
    void Update()
    {
        timeInLevel += Time.deltaTime;
    }

    //ζητάει να φερθεί ο παίχτης πίσω στην ζωή
    public void RespawnPlayer(){
        StartCoroutine(RespawnCoroutine());
    }

    //περιμένει κάποια ώρα μέχρι να φέρει τον παίχτη πίσω στην ζωή
    IEnumerator RespawnCoroutine(){
        
        PlayerController.instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(WaitToRespawn - (1/UIController.instance.fadeSpeed));
        UIController.instance.FadeIn();
        
        yield return new WaitForSeconds((1/UIController.instance.fadeSpeed) + 0.2f);
        UIController.instance.FadeOut();

        PlayerController.instance.gameObject.SetActive(true);

        PlayerController.instance.transform.position = CheckpointController.instance.spawnPoint;
        PlayerHealthController.instance.currentHealth = PlayerHealthController.instance.maxHealth;
        UIController.instance.UpdateHealthDisplay();
    }

    //ζητάει να τελειώσει το επίπεδο
    public void EndLevel(){
        StartCoroutine(EndLevelCoroutine());
    }

    //περιμένει κάποια ώρα μέχρι να τελειώσει το επίπεδο
    public IEnumerator EndLevelCoroutine(){
        Time.timeScale = 0.5f;

        AudioManager.instance.PlayLevelVictory();

        PlayerController.instance.stopInput = true;
        CameraController.instance.StopFollowingPlayer = true;

        UIController.instance.levelCompleteText.SetActive(true);

        yield return new WaitForSeconds(2.5f);

        Time.timeScale = 1;

        UIController.instance.FadeIn();
        yield return new WaitForSeconds((1/ UIController.instance.fadeSpeed) + 2f);

        PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_unlocked", 1);
        PlayerPrefs.SetString("currentLevel", SceneManager.GetActiveScene().name);

        if(PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_gems")){
            if(gemsCollected > PlayerPrefs.GetInt(SceneManager.GetActiveScene().name + "_gems")){
                PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemsCollected);
            }
        }else{
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name + "_gems", gemsCollected);
        }
        
        if(PlayerPrefs.HasKey(SceneManager.GetActiveScene().name + "_time")){
            if(timeInLevel < PlayerPrefs.GetFloat(SceneManager.GetActiveScene().name + "_time"))
                PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
        }else{
            PlayerPrefs.SetFloat(SceneManager.GetActiveScene().name + "_time", timeInLevel);
        }

        SceneManager.LoadScene(levelToLoad);
    }

    public void RestartLevel(int restartedLevel){
        SceneManager.LoadScene(restartedLevel);
    }
}
