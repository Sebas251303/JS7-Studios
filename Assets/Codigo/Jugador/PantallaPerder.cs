using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PantallaPerder : MonoBehaviour
{
    public PlayerController player;
    public float tiempoEspera = 2f; // configurable desde el Inspector
    private bool escenaCargando = false;

    void Update()
    {
        if (player != null && player.muerto && !escenaCargando)
        {
            escenaCargando = true;
            StartCoroutine(CargarPantallaPerder());
        }
    }

    private System.Collections.IEnumerator CargarPantallaPerder()
    {
        // Espera el tiempo configurado
        yield return new WaitForSeconds(tiempoEspera);
        SceneManager.LoadScene("Perder");
    }
}




