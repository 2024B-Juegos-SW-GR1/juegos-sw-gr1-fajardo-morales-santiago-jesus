using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float velocidad =  10f;

    [SerializeField] private float xValue =  0f;
    [SerializeField] private float yValue =  0.05f;
    [SerializeField] private float zValue =  0f;


    // Start is called before the first frame update
    void Start()
    {
        ImprimirInstrucciones();
    }

    void ImprimirInstrucciones()
    {
        Debug.Log("Bienvenido al juego");
        Debug.Log("Muevete con las flechas");
        Debug.Log("No te muevas dentro de los objetos");

    }

    void MoverAlJugador()
    {
        float movimientoX = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;
        float movimientoY = 0f;
        float movimientoZ = Input.GetAxis("Vertical") * Time.deltaTime * velocidad;
        transform.Translate(movimientoX, movimientoY, movimientoZ);  
    }

    private int colisiones = 0;
    void OnCollisionEnter()
    {
        colisiones++;
        Debug.Log("He golpeado un objeto "+colisiones+" veces");
    }

    // Update is called once per frame
    void Update()
    {
        MoverAlJugador();
    }
}
