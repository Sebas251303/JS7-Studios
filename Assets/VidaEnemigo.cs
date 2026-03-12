using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    [Header("Ajustes de Salud")]
    public int vidaActual = 100;
    public int vidaMaxima = 100;

    Animator anim;
    private bool estaMuerto = false;

    void Start()
    {
        anim = GetComponent<Animator>();
        vidaActual = vidaMaxima;
    }

    // Esta es la función que llamará la bola de fuego
    public void RecibirDanio(int cantidad)
    {
        if (estaMuerto) return;

        vidaActual -= cantidad;
        Hurt(); // Llama a tu función de animación

        if (vidaActual <= 0)
        {
            Morir();
        }
    }

    void Morir()
    {
        estaMuerto = true;
        Smoke(); // Usamos la animación de Smoke (humo) como muerte

        // Desactivamos colisiones para que no estorbe
        GetComponent<Collider2D>().enabled = false;

        // Opcional: Destruir el objeto después de que termine el humo
        Destroy(gameObject, 1f);
    }

    // --- Tus funciones originales ---
    public void Attack() { anim.SetTrigger("Attack"); }
    public void Hurt() { anim.SetTrigger("Hurt"); }
    public void Smoke() { anim.SetTrigger("Smoke"); }

    void Update()
    {
        if (estaMuerto) return;

        // Mantengo tus teclas de prueba
        if (Input.GetKeyDown(KeyCode.A)) Attack();
        if (Input.GetKeyDown(KeyCode.H)) Hurt();
        if (Input.GetKeyDown(KeyCode.K)) Smoke();
    }
}