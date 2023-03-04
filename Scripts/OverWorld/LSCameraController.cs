using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSCameraController : MonoBehaviour
{
    //μεταβλητές για να μπορεί η κάμερα να ακολουθεί τον παίχτη
    public Vector2 minPos, maxPos;
    public Transform target;

    //καλείται μια φορά κάθε frame αμέσως μετά από το update()
    void LateUpdate()
    {
        FollowPlayer();
    }

    //Ακολουθεία παίχτη
    private void FollowPlayer()
    {
        float xPos = Mathf.Clamp(target.position.x, minPos.x, maxPos.x);
        float yPos = Mathf.Clamp(target.position.y, minPos.y, maxPos.y);

        transform.position = new Vector3(xPos, yPos, transform.position.z);
    }
}
