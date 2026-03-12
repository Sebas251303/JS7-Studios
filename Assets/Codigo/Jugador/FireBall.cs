using UnityEngine;

public class FireBall : MonoBehaviour
{
    public float velocidad = 10f;
    public float tiempoVida = 2f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Destruir la bola después de 2 segundos para no llenar la memoria
        Destroy(gameObject, tiempoVida);
    }

    void Update()
    {
        // Se mueve hacia donde esté mirando el dragón
        float direccion = transform.localScale.x;
        rb.velocity = new Vector2(velocidad * direccion, 0);
    }
}
