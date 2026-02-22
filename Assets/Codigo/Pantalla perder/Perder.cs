using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Perder : MonoBehaviour
{
  
    public void Salir()
    {
        SceneManager.LoadScene("Menu"); 
    }

   
    public void Intentar()
    {
        
        // SceneManager.LoadScene("Mapa"); // cuando la tengas creada
       
    }

}
