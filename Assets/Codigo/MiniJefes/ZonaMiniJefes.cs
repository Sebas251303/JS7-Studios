using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaMiniJefes : MonoBehaviour
{
    public GameObject paredEntrada;   
    public GameObject paredSalida;    
    public GameObject miniBoss;       

    private bool activado = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!activado && other.CompareTag("Player"))
        {
            activado = true;

            CerrarZona();
        }
    }

    void CerrarZona()
    {
        // Activar paredes
        paredEntrada.SetActive(true);
        paredSalida.SetActive(true);

 
    }

    public void AbrirZona()
    {
        // Desactivar paredes
        paredEntrada.SetActive(false);
        paredSalida.SetActive(false);
    }
}
