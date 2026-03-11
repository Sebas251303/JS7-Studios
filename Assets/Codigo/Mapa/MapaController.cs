using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MapaController : MonoBehaviour
{
    void Start()
    {
       
        SceneManager.LoadScene("Menu", LoadSceneMode.Additive);

     
        Time.timeScale = 0;
    }

    public void IniciarJuego()
    {
        Time.timeScale = 1; 
    }
}


