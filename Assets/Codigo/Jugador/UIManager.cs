using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> listaCorazones;
    [SerializeField] private  Sprite corazonDesactivado;
    

    public void RestaCorazones (int indice)
    {
        Image imagenCorazon =  listaCorazones[indice].GetComponent<Image>();
        imagenCorazon.sprite = corazonDesactivado;

    }
  
}
