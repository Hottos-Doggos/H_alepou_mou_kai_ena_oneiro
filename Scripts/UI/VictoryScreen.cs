using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    public string mainMenu;
    //καλείται στο πρώτο frame
    void Start()
    {
        Cursor.visible = true;
    }

    //σε πηγαίνει στο βασικό μενού
    public void MainMenu(){
        SceneManager.LoadScene(mainMenu);
    }

    //κλείνει το παιχνίδι
    public void QuitGame(){
        Application.Quit();
    }
}
