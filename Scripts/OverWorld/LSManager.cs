using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LSManager : MonoBehaviour
{
    //reference(δεν μπόρεσα να βρω μια σωστή ελληνική λέξη) του παίχτη 
    public LSPlayer player;

    //μεταβλητές για να εμφανίζεται ο παίχτης στο σωστό σημείο του χάρτη
    private MapPoint[] allPoints;


    //καλείται στο πρώτο frame
    void Start()
    {
        MoveToCorrectPosition();
    }

    //ζητάει να φορτωθεί το επίπεδο
    public void LoadLevel(){
        StartCoroutine(LoadLevelCoroutine());
    }

    //περιμένει για κάποια δευτερόλεπτα και φορτώνει το επίπεδο
    IEnumerator LoadLevelCoroutine(){
        LS_UIController.instance.FadeIn();

        yield return new WaitForSeconds((1f / LS_UIController.instance.fadeSpeed) + 0.25f);
        
        SceneManager.LoadScene(player.currentPoint.levelToLoad);
    }

    void MoveToCorrectPosition(){
        allPoints = FindObjectsOfType<MapPoint>();
        if(PlayerPrefs.HasKey("currentLevel")){
            foreach (MapPoint point in allPoints)
            {
                if(point.levelToLoad == PlayerPrefs.GetString("currentLevel")){
                    player.transform.position = point.transform.position;
                    player.currentPoint = point;
                }
            }
        }
    }
}
