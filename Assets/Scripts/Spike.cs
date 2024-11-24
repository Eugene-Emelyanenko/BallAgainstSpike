using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            GameObject canvas = GameObject.Find("UI");
            if (canvas != null)
            {
                Transform leaderBoard = canvas.transform.Find("LeaderBoardMenu");
                if (leaderBoard != null)
                {
                    leaderBoard.gameObject.SetActive(true);
                }
                else
                {
                    Debug.LogError("LeaderBoard error");
                }
            }
            else
            {
                Debug.LogError("Canvas error");
            }
            
            PlayerController.canInput = false;
        }
    }
}
