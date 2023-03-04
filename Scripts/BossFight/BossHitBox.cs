using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitBox : MonoBehaviour
{
    //αναφορά του εχθρού ώστε να μπορεί να δει ότι έχει χτυπηθεί
    public BossFightController bossCont;

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && PlayerController.instance.transform.position.y > transform.position.y){
            bossCont.GetHit();
            AudioManager.instance.PlaySFX(0);

            PlayerController.instance.Bounce();
            gameObject.SetActive(false);
        }
    }
}
