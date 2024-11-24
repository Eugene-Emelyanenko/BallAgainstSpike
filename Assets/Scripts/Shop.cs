using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public int coins;

    [SerializeField] private Text coinsText;
    [SerializeField] private Image[] balls;
    [SerializeField] private Sprite[] unlockedBalls;
    [SerializeField] private Sprite lockedBall;
    [SerializeField] private Sprite[] chosedBall;


    private List<int> colors = new List<int>() { 1, 0, 0, 0, 0, 0 };

    public int selectedBall;
    void Start()
    {
        coins = PlayerPrefs.GetInt("coins");

        selectedBall = PlayerPrefs.GetInt("selectedBall", 0);

        colors[0] = PlayerPrefs.GetInt("football", 1);
        colors[1] = PlayerPrefs.GetInt("baseball", 0);
        colors[2] = PlayerPrefs.GetInt("basketball", 0);
        colors[3] = PlayerPrefs.GetInt("bouling", 0);
        colors[4] = PlayerPrefs.GetInt("tennis", 0);
        colors[5] = PlayerPrefs.GetInt("billiard", 0);
        
        PlayerPrefs.SetInt("coins", coins);
        
        PlayerPrefs.SetInt("selectedBall", selectedBall);
        
        PlayerPrefs.SetInt("football", colors[0]);
        PlayerPrefs.SetInt("baseball", colors[1]);
        PlayerPrefs.SetInt("basketball", colors[2]);
        PlayerPrefs.SetInt("bouling", colors[3]);
        PlayerPrefs.SetInt("tennis", colors[4]);
        PlayerPrefs.SetInt("billiard", colors[5]);

        UpdateUI();
    }

    public void OpenBall(int id)
    {
        string color = id == 0 ? "football" : id == 1 ? "baseball" : id == 2 ? "basketball" : id == 3 ? "bouling" : id == 4 ? "tennis" : id == 5 ? "billiard" : String.Empty;

        if (PlayerPrefs.GetInt(color) == 0)
        {
            if (coins >= 50)
            {
                coins -= 50;
                PlayerPrefs.SetInt("coins", coins);

                colors[id] = 1;

                selectedBall = id;
                PlayerPrefs.SetInt("selectedBall", selectedBall);
            
                PlayerPrefs.SetInt(color, 1);
            }
            else
            {
                colors[id] = 0;
                PlayerPrefs.SetInt(color, 0);
                Debug.Log("No Money");
            }
        }
        else
        {
            selectedBall = id;
            PlayerPrefs.SetInt("selectedBall", selectedBall);
            Debug.Log("Already Has");
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        coinsText.text = coins.ToString();
        
        for (int i = 0; i < colors.Count; i++)
        {
            balls[i].sprite = colors[i] == 1 ? unlockedBalls[i] : lockedBall;
        }

        balls[selectedBall].sprite = chosedBall[selectedBall];
    }
}
