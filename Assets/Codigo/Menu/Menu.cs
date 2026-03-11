using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public void Jugar()
    {

          
       FindObjectOfType<MapaController>().IniciarJuego();

           
       gameObject.SetActive(false);

    }

    public void Salir()
    {
        Application.Quit(); 
        Debug.Log("Salir del juego"); 
    }

}
