using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ganar : MonoBehaviour
{
  
    public void Salir()
    {
        SceneManager.LoadScene("Menu"); 
    }

   
    public void Siguiente()
    {
        
         SceneManager.LoadScene("Mapa"); 
       
    }

}
