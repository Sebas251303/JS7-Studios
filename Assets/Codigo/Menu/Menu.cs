using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string nombreEscenaMapa = "Mapa"; // 👈 nombre exacto de tu escena

    public void Jugar()
    {
        // Intenta usar MapaController si existe
        MapaController mapa = FindObjectOfType<MapaController>();
        if (mapa != null)
        {
            mapa.IniciarJuego();
            gameObject.SetActive(false);
        }
        else
        {
            // Si no existe, carga la escena Mapa directamente
            SceneManager.LoadScene(nombreEscenaMapa);
        }
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salir del juego");
    }
}