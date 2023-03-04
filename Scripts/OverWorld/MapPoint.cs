using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPoint : MonoBehaviour
{
    //μεταβλητές για επιλογή επιπέδου
    public MapPoint up, right, down, left;
    public bool isLevel, isLocked;
    public string levelToLoad, levelToCheck, levelName;

    //μεταβλητές για πληροφορίες επιπέδων
    public int gemsCollected, totalGems;
    public float timeBest, timeTarget;
    public GameObject gemBadge, timeBadge;


    //καλείται στο πρώτο frame
    void Start()
    {
        UnlockLevel();
    }

    //καλείται μια φορά κάθε frame
    void Update()
    {
        
    }

    //ξεκλειδώνει τα κλειδωμένα επίπεδα
    void UnlockLevel(){
        if(isLevel && levelToLoad != null){
            if(PlayerPrefs.HasKey(levelToLoad + "_gems")){
                gemsCollected = PlayerPrefs.GetInt(levelToLoad + "_gems");
            }
            if(PlayerPrefs.HasKey(levelToLoad + "_time")){
                timeBest = PlayerPrefs.GetFloat(levelToLoad + "_time");
            }

            if(gemsCollected >= totalGems){
                gemBadge.SetActive(true);
            }
            if(timeBest <= timeTarget && timeBest != 0){
                timeBadge.SetActive(true);
            }

            isLocked = true;

            if(levelToCheck != null){
                if(PlayerPrefs.HasKey(levelToCheck + "_unlocked")){
                    if(PlayerPrefs.GetInt(levelToCheck + "_unlocked") == 1){
                        isLocked = false;
                    }
                }
            }
        }if(levelToLoad == levelToCheck){
            isLocked = false;
        }
    }
}
