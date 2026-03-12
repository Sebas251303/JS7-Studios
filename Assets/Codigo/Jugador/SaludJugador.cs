using UnityEngine;
using UnityEngine.UI; // Necesario para controlar el texto x3

public class SaludJugador : MonoBehaviour
{
    [Header("Configuración")]
    public int vidas = 3;
    public Text textoVidas; // Aquí arrastra el objeto "TextoVida" del Canvas

    private bool esInvulnerable = false;
    public float tiempoInvulnerabilidad = 1f;

    void Start()
    {
        ActualizarUI();
    }

    // Esta es la función que llama el murciélago
    public void RecibirDanio()
    {
        if (esInvulnerable || vidas <= 0) return;

        vidas--;
        ActualizarUI();

        // Activamos la animación de daño (Hurt) que ya tienes
        GetComponent<Animator>().SetTrigger("Hurt");

        if (vidas <= 0)
        {
            Morir();
        }
        else
        {
            StartCoroutine(Invulnerabilidad());
        }
    }

    void ActualizarUI()
    {
        if (textoVidas != null)
        {
            textoVidas.text = "x" + vidas.ToString();
        }
    }

    void Morir()
    {
        GetComponent<Animator>().SetTrigger("Die");
        GetComponent<PlayerController>().enabled = false; // Bloquea controles
        Debug.Log("Game Over");
    }

    System.Collections.IEnumerator Invulnerabilidad()
    {
        esInvulnerable = true;
        // Opcional: podrías hacer que el sprite parpadee aquí
        yield return new WaitForSeconds(tiempoInvulnerabilidad);
        esInvulnerable = false;
    }
}