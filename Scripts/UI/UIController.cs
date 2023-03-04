using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public static UIController instance;
    
    //μεταβλητές για την ζωή του παίχτη
    public Image heart1, heart2, heart3;
    public Sprite heartFull, heartHalf, heartEmpty;

    //μεταβλητές για τα διαμάντια του παίχτη
    public Text gemText;

    //μεταβλητές για μαύρισμα της οθόνης
    public Image fadeScreen;
    public float fadeSpeed;
    bool shouldFadeToBlack, shouldFadeFromBlack;

    //μεταβλητές για εμφάνιση κειμένου τέλους
    public GameObject levelCompleteText;


    //καλείται πριν το πρώτο frame
    void Awake(){
        instance = this;
    }

    //καλείται στο πρώτο frame
    void Start()
    {
        UpdateGemDisplay();
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

    //αλλαγή UI της καρδιάς σύμφωνα με την ζωή του παίχτη
    public void UpdateHealthDisplay(){
        switch (PlayerHealthController.instance.currentHealth)
        {
            case 6:
            heart1.sprite = heartFull;
            heart2.sprite = heartFull;
            heart3.sprite = heartFull;
            break;

            case 5:
            heart1.sprite = heartFull;
            heart2.sprite = heartFull;
            heart3.sprite = heartHalf;
            break;

            case 4:
            heart1.sprite = heartFull;
            heart2.sprite = heartFull;
            heart3.sprite = heartEmpty;
            break;
            
            case 3:
            heart1.sprite = heartFull;
            heart2.sprite = heartHalf;
            heart3.sprite = heartEmpty;
            break;

            case 2:
            heart1.sprite = heartFull;
            heart2.sprite = heartEmpty;
            heart3.sprite = heartEmpty;
            break;

            case 1:
            heart1.sprite = heartHalf;
            heart2.sprite = heartEmpty;
            heart3.sprite = heartEmpty;
            break;

            case 0:
            heart1.sprite = heartEmpty;
            heart2.sprite = heartEmpty;
            heart3.sprite = heartEmpty;
            break;
        }
    }

    //εμφανίζει πόσα διαμάντια έχει μαζέψει ο παίχτης
    public void UpdateGemDisplay(){
        gemText.text = LevelManager.instance.gemsCollected.ToString();
    }
}
