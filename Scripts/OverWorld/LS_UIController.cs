using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LS_UIController : MonoBehaviour
{
    public static LS_UIController instance;

    //μεταβλητές για μαύρισμα της οθόνης
    public Image fadeScreen;
    public float fadeSpeed;
    bool shouldFadeToBlack, shouldFadeFromBlack;

    //μεταβλητές για εμφάνιση πληροφοριών επιπέδων
    public GameObject levelInfoPanel;
    public Text levelName, gemsFound, gemsTarget, timeBest, timeTarget;


    //καλείται πριν το πρώτο frame
    void Awake(){
        instance = this;
    }

    //καλείται στο πρώτο frame
    void Start()
    {
        FadeOut();
    }
    
    //καλείται μια φορά κάθε frame
    void Update()
    {
        FadeInAndOut();
    }

    //έλεγχος μαυρίσματος της οθόνης
    private void FadeInAndOut()
    {
        if(shouldFadeToBlack){
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1, fadeSpeed * Time.deltaTime));

            if(fadeScreen.color.a == 1){
                shouldFadeToBlack = false;
            }
        }

        if(shouldFadeFromBlack){
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0, fadeSpeed * Time.deltaTime));

            if(fadeScreen.color.a == 0){
                shouldFadeFromBlack = false;
            }
        }
    }

    //μαυρίζει την οθόνη
    public void FadeIn(){
        shouldFadeToBlack = true;
        shouldFadeFromBlack = false;
    }

    //ξεμαυρίζει την οθόνη
    public void FadeOut(){
        shouldFadeToBlack = false;
        shouldFadeFromBlack = true;
    }

    //εμφάνιση πληροφοριών των επιπέδων
    public void ShowLevelInfo(MapPoint levelInfo){
        levelName.text = levelInfo.levelName;

        gemsFound.text = "Βρήκες:" + levelInfo.gemsCollected;
        gemsTarget.text = "Υπάρχουν:" + levelInfo.totalGems;

        if(levelInfo.timeBest == 0)
            timeBest.text = "Καλύτερος:---";
        else
            timeBest.text = "Καλύτερος:" + levelInfo.timeBest.ToString("f1") + '"';
        
        timeTarget.text = "Στόχος:" + levelInfo.timeTarget + '"';

        levelInfoPanel.SetActive(true);
    }

    //απόκριψη πληροφοριών των επιπέδων
    public void HideLevelInfo(){
        levelInfoPanel.SetActive(false);
    }
}
