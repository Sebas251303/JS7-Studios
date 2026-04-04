using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapaController : MonoBehaviour
{
    void Start()
    {
        // Carga el menú de forma aditiva
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);

        // Pausa el juego
        Time.timeScale = 0;
    }

    public void IniciarJuego()
    {
        // Reanuda el juego
        Time.timeScale = 1;

        // Busca la cámara del menú por su tag y la desactiva
        GameObject menuCam = GameObject.FindGameObjectWithTag("MenuCam");
        if (menuCam != null)
        {
            menuCam.SetActive(false);
        }
    }
}