using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetoGolpeable : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Objeto Golpeado");
        GetComponent<MeshRenderer>().material.color = Color.gray;
}
}
