using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //μεταβλητές για ξεκίνημα ή συνέχεια του παιχνιδιού
    public string startScene, continueScene;
    public GameObject continueButton;

    
    //καλείται στο πρώτο frame
    void Start()
    {
        Cursor.visible = true;
        ShowContinueButton();
    }

    //ξεκινάει το παιχνίδι από την αρχή
    public void StartGame(){
        SceneManager.LoadScene(startScene);
        PlayerPrefs.DeleteAll();
    }

    //εμφανίζει το κουμπί συνέχεια αν ο παίχτης έχει παίξει
    void ShowContinueButton(){
        if(PlayerPrefs.HasKey("Level 1" + "_unlocked"))
            continueButton.SetActive(true);
        else
            continueButton.SetActive(false);
    }

    //συνεχίζει το παιχνίδι
    public void ContinueGame(){
        SceneManager.LoadScene(continueScene);
    }

    //κλείνει το παιχνίδι
    public void QuitGame(){
        Application.Quit();
    }
}
