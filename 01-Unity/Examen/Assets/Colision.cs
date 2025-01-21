using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colision : MonoBehaviour
{
    private bool hasPackage;
    [SerializeField] private float destroyDelay = 0.5f;
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("GOLPEEE");
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Entrando a trigger");

        if (other.CompareTag("Paquete") && !hasPackage)
        {
            Debug.Log("Paquete recogido");
            hasPackage = true;
            Destroy(other.gameObject, destroyDelay);
        }
        if (other.CompareTag("Cliente") && hasPackage)
        {
            Debug.Log("Paquete entregado");
            hasPackage = false;
            _spriteRenderer.color = Color.red;
        }
    }
}
