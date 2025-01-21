using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public GameObject cristalMagico;

    void Update()
    {
        if (cristalMagico.GetComponent<SpriteRenderer>().color == Color.green)
        {
            gameObject.SetActive(false); // Desactiva la puerta
        }
    }
}
