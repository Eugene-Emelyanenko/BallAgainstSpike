using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Manager : MonoBehaviour
{
    [SerializeField] private GameObject[] spikes;
    [SerializeField] private GameObject coin;
    [SerializeField] private Transform[] coinSpawners;
    private GameObject currentSpike;
    public Sprite[] balls;

    private const float StartBallRotationSpeed = -35f;
    private const float StartObstacleRotationSpeed = 35f;

    void Start()
    {
        ChangeSpike();
        
        PlayerController.rotationSpeed = StartBallRotationSpeed;
        Circle.rotationSpeed = StartObstacleRotationSpeed;
    }

    public void Change()
    {
        ChangeSpike();

        PlayerController.rotationSpeed -= 1f;
        Circle.rotationSpeed += 1f;
    }

    private void ChangeSpike()
    {
        for (int i = 0; i < spikes.Length; i++)
        {
            spikes[i].SetActive(false);
        }
        
        currentSpike = spikes[Random.Range(0, spikes.Length)];
        currentSpike.SetActive(true);

        Instantiate(coin, coinSpawners[Random.Range(0, coinSpawners.Length)].position, Quaternion.identity);
    }
}
