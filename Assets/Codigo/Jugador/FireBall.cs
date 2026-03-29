using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float velocidad = 10f;
    public float tiempoVida = 3f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Calculamos la direccion basada en la escala (1 o -1)
        float direccion = transform.localScale.x;
        rb.velocity = new Vector2(velocidad * direccion, 0);

        // Se destruye sola tras unos segundos por si no choca con nada
        Destroy(gameObject, tiempoVida);
    }

    // ESTO ES LO QUE HACE QUE DESAPAREZCA AL CHOCAR
private void OnCollisionEnter2D(Collision2D collision)
{
    // Verificamos si golpea a un enemigo
    VidaEnemigo enemigo = collision.gameObject.GetComponent<VidaEnemigo>();

    if (enemigo != null)
    {
        enemigo.RecibirDanio(1); // Puedes ajustar el daño
    }

    // Se destruye siempre
    Destroy(gameObject);
}
}