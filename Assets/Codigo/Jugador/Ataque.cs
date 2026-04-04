using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque : MonoBehaviour
{
    public float velocidad = 10f;
    public float tiempoVida = 2f;
    void Start()
    {
         Destroy(gameObject, tiempoVida);
    }

    
    void Update()
    {
        transform.Translate(Vector2.right * velocidad * Time.deltaTime);
    }
}
