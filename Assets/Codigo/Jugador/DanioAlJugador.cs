using UnityEngine;

public class DanioAlJugador : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Buscamos directamente el script SaludJugador en lo que acabamos de chocar
        SaludJugador salud = collision.gameObject.GetComponent<SaludJugador>();

        if (salud != null)
        {
            // Si encontramos el script, le quitamos vida
            salud.RecibirDanio();
            Debug.Log("¡Le quité vida al dragón!");
        }
        else
        {
            // Si no lo encuentra, nos dirá con qué chocó exactamente
            Debug.Log("Choqué con " + collision.gameObject.name + " pero no tiene script de Salud.");
        }
    }
}