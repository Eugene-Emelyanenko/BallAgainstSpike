using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform centerObject;
    public static float rotationSpeed = -35f;
    public float rollingSpeed = 60f;
    public float innerRadius = 1.55f;
    public float outerRadius = 2f;

    private float currentRadius;
    private float angle = 0.0f;
    public bool inner;

    public static bool canInput;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = FindObjectOfType<Manager>().balls[PlayerPrefs.GetInt("selectedBall", 0)];
        canInput = true;
        currentRadius = innerRadius;
        inner = false;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) && canInput)
        {
            inner = !inner;
            currentRadius = inner ? outerRadius : innerRadius;
            rollingSpeed *= -1f;
        }

        angle += rotationSpeed * Time.deltaTime;

        Vector3 newPosition = centerObject.position + Quaternion.Euler(0, 0, angle) * Vector3.right * currentRadius;

        transform.position = newPosition;
        
        transform.Rotate(Vector3.forward, rollingSpeed * Time.deltaTime);
    }
}
