using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //μεταβλητές για κίνηση της πλατφόρμας
    public Transform[] points;
    public float moveSpeed;
    public int currentPoint;
    public Transform platform;


    //καλείται μια φορά κάθε frame
    void Update()
    {
        Move();
    }

    //κουνάει την πλατφόρμα
    void Move(){
        platform.position = Vector3.MoveTowards(platform.position, points[currentPoint].position, moveSpeed * Time.deltaTime);   

        if(Vector3.Distance(platform.position, points[currentPoint].position) < 0.5f){
            currentPoint++;

            if(currentPoint >= points.Length){
                currentPoint = 0;
            }
        }
    }
}
