using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightsource : MonoBehaviour
{
    public LineRenderer lineRenderer; // Asigna un LineRenderer en Unity
    public LayerMask collisionLayer; // Define qué capas pueden colisionar con el rayo

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        Debug.Log("Empiezo");
    }

    void Update()
    {
        Vector2 startPoint = transform.position;
        Vector2 direction = Vector2.right; // Dirección inicial del rayo
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, startPoint);

        for (int i = 0; i < 10; i++) // Limita los rebotes del rayo
        {
            RaycastHit2D hit = Physics2D.Raycast(startPoint, direction, Mathf.Infinity, collisionLayer);
            if (hit.collider != null)
            {
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);

                if (hit.collider.CompareTag("Espejo"))
                {
                    // Reflexión
                    Debug.Log("espejo");

                    direction = Vector2.Reflect(direction, hit.normal);
                    startPoint = hit.point;
                }
                else if (hit.collider.CompareTag("CristalMagico"))
                {
                    // Acción específica si golpea el cristal
                    hit.collider.GetComponent<SpriteRenderer>().color = Color.green;
                    break;
                }
                else
                {
                    break;
                }
            }
            else
            {
                // Si no hay colisión, termina el rayo
                lineRenderer.positionCount++;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, startPoint + direction * 100);
                break;
            }
        }
    }
}
