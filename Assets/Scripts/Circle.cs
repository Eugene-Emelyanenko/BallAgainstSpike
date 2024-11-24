using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    public static float rotationSpeed = 35f;
    private void Update()
    { 
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }
}
