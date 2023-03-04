using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float lifeTime;  //μεταβλητή διάρκειας πριν την καταστροφή

    //καλείται μια φορά κάθε frame
    void Update()
    {
        Destroy(gameObject, lifeTime);
    }
}
