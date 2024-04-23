using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public Canvas gameover;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) { 
        
            gameover.gameObject.SetActive(true);
            gameover.enabled = true;
            Time.timeScale = 0f;
        }
    }




}
