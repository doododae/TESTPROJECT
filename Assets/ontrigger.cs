using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onTrigger : MonoBehaviour
{   
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Player") {
            death();
        }
    }

    private void death() {
        gameManager.gameOver();
    }
}
