using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LSPlayer : MonoBehaviour
{
    public LSManager manager;

    //μεταβλητές για κίνηση του παίχτη
    public MapPoint currentPoint;
    public float moveSpeed;

    //μεταβλητές επιλογής επιπέδων
    bool levelLoading;


    //καλείται στο πρώτο frame
    void Start()
    {
        
    }

    //καλείται μια φορά κάθε frame
    void Update()
    {
        Move();
    }

    //κίνηση του παίχτη και επιλογή επιπέδου
    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.transform.position, moveSpeed * Time.deltaTime);

        if(Vector3.Distance(transform.position, currentPoint.transform.position) <= 0 && !levelLoading){


            if(Input.GetAxisRaw("Horizontal") > 0.5f){
                if(currentPoint.right != null){
                    SetNextPoint(currentPoint.right);
                }
            }
        
            if(Input.GetAxisRaw("Horizontal") < -0.5f){
                if(currentPoint.left != null){
                    SetNextPoint(currentPoint.left);
                }
            }

            if(Input.GetAxisRaw("Vertical") > 0.5f && !(Input.GetAxisRaw("Horizontal") < -0.5f) && !(Input.GetAxisRaw("Horizontal") > 0.5f)){
                if(currentPoint.up != null){
                    SetNextPoint(currentPoint.up);
                }
            }

            if(Input.GetAxisRaw("Vertical") < -0.5f && !(Input.GetAxisRaw("Horizontal") < -0.5f) && !(Input.GetAxisRaw("Horizontal") > 0.5f)){
                if(currentPoint.down != null){
                    SetNextPoint(currentPoint.down);
                }
            }

            if(currentPoint.isLevel && currentPoint.levelToLoad != "" && !currentPoint.isLocked){
                LS_UIController.instance.ShowLevelInfo(currentPoint);

                if(Input.GetButtonDown("Jump")){
                    levelLoading = true;
                    manager.LoadLevel();
                }
            }
        }
    }

    //πηγαίνει τον παίχτη στο επόμενο σημείο του χάρτη και κρύβει τις πληροφορίες
    void SetNextPoint(MapPoint nextPoint){
        currentPoint = nextPoint;
        LS_UIController.instance.HideLevelInfo();
    }
}
