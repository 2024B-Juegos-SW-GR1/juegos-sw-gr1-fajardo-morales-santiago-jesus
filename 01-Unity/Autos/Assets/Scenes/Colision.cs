using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lol : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("GOLPEEE");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entrando a trigger");
        if (CompareTag("Paquete"))
        {
            Debug.Log("Paquete recogido");
        }
        if (CompareTag("Cliente"))
        {
            Debug.Log("Paquete entregado");
        }
    }
}
