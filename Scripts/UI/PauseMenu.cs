using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;

    //μεταβλητές για επιλογή σκηνής
    public string levelSelect, mainMenu;

    //μεταβλητές για την σκηνή παύσης
    public GameObject pauseScreen;
    public bool isPaused;



    //καλείται πριν το πρώτο frame
    private void Awake() {
        instance = this;
    }

    //καλείται στο πρώτο frame
    void Start()
    {
        Cursor.visible = false;
    }

    //καλείται μια φορά κάθε frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            PauseAndUnpause();
        }
    }

    //κάνει και ξεκάνει pause το παιχνίδι
    public void PauseAndUnpause(){
        if(isPaused){
            isPaused = false;
            pauseScreen.SetActive(false);
            Cursor.visible = false;
            Time.timeScale = 1;
        }else{
            isPaused = true;
            pauseScreen.SetActive(true);
            Cursor.visible = true;
            Time.timeScale = 0;
        }
    }

    //πηγαίνει στην επιλογή επιπέδου
    public void LevelSelect(){
        PlayerPrefs.SetString("currentLevel", SceneManager.GetActiveScene().name);

        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1;
    }

    //πηγαίνει στο βασικό μενού
    public void MainMenu(){
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1;
    }
}
