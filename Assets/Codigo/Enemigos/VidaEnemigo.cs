using UnityEngine;
using UnityEngine.SceneManagement;

public class VidaEnemigo : MonoBehaviour
{
    public int vidaMaxima = 2;
    private int vidaActual;
    private bool estaMuerto = false;
    public Animator anim;
    public ZonaMiniJefes zona;

    void Start()
    {
        vidaActual = vidaMaxima;
    }

    public void RecibirDanio(int cantidad)
    {
        if (estaMuerto) return;

        vidaActual -= cantidad;

        
        if (anim != null)
        {
            anim.SetTrigger("Hit");
        }

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        estaMuerto = true;

       
        if (anim != null)
        {
            anim.SetTrigger("Die");
            anim.SetBool("Die", true);
        }

        MiniJefes movimiento = GetComponent<MiniJefes>();
        if (movimiento != null)
        {
    movimiento.enabled = false;
        }

        Collider2D col = GetComponent<Collider2D>();
        if (col != null)
        {
            col.enabled = false;
        }

        if (zona != null)
        {
            zona.AbrirZona();
        }

         Invoke("CargarEscenaGanar", 1f);



        Destroy(gameObject, 1f);
    }
    void CargarEscenaGanar()
    {
        SceneManager.LoadScene("Ganar");
    }

}