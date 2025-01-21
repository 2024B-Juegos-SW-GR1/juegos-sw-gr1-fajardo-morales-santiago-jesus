using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrastrar : MonoBehaviour
{
    private Camera mainCamera; // Cámara principal
    private Rigidbody2D rb; // Referencia al Rigidbody2D
    private bool isDragging = false; // Si el objeto está siendo arrastrado
    private Vector2 offset; // Desplazamiento entre el mouse y el objeto

    void Start()
    {
        mainCamera = Camera.main;
        rb = GetComponent<Rigidbody2D>();

        // Asegurarte de que el Rigidbody2D esté configurado correctamente
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic; // Activa la física
            rb.freezeRotation = true; // Desactiva la rotación
        }
    }

    void OnMouseDown()
    {
        // Detecta el clic y calcula el offset
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        offset = (Vector2)transform.position - mousePosition;

        // Habilita el arrastre y pasa el Rigidbody a modo kinemático
        isDragging = true;
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Kinematic; // Desactiva las fuerzas físicas
        }
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            // Obtén la posición del mouse y mueve el objeto con offset
            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 targetPosition = mousePosition + offset;

            // Establece la posición usando el Rigidbody para respetar las colisiones
            rb.MovePosition(targetPosition);
        }
    }

    void OnMouseUp()
    {
        // Finaliza el arrastre y reactiva la física
        isDragging = false;
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic; // Reactiva las fuerzas físicas
        }
    }
}
