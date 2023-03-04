using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instance;

    //μεταβλητές κίνησης
    public Transform target;
    public Transform farBg, middleBg;
    Vector2 lastPos;
    public float minHeight, maxHeight;
    public bool StopFollowingPlayer;


    //καλείται πριν το πρώτο frame
    private void Awake() {
        instance = this;
    }

    //καλείται στο πρώτο frame
    void Start()
    {
        lastPos = transform.position;
    }

    //καλείται μια φορά κάθε frame
    void Update()
    {
        MoveCamera();
    }

    //κίνηση της κάμερας
        private void MoveCamera(){
            if(!StopFollowingPlayer){
                transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);
                MoveBackgrounds();
            }
        }

    //ομαλή κίνηση των backgrounds
    private void MoveBackgrounds(){
        Vector2 amountToMove = new Vector2(transform.position.x - lastPos.x, transform.position.y -lastPos.y);

        farBg.position = farBg.position + new Vector3(amountToMove.x, amountToMove.y, 0f);
        middleBg.position += new Vector3(amountToMove.x, amountToMove.y, 0f) * 0.5f;
        
        lastPos = transform.position;
        
    }
}
