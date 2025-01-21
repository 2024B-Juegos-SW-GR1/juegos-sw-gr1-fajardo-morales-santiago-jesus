using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espejo : MonoBehaviour
{
    public float rotationSpeed = 90f;

    void OnMouseDown()
    {
        transform.Rotate(0, 0, rotationSpeed); // Gira el espejo en el plano 2D
    }
}
