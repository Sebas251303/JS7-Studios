using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    public int vidaMaxima = 2;
    private int vidaActual;
    private bool estaMuerto = false;
    public Animator anim;

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDanio(int cantidad)
    {
        if (estaMuerto) return;

        vidaActual -= cantidad;


        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        estaMuerto = true;
        anim.SetTrigger("Die");

        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.enabled = false;
        }

        Destroy(gameObject, 1f);
    }
}