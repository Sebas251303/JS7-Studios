using UnityEngine;

public class Fireball : MonoBehaviour
{
    [Header("Ajustes del Disparo")]
    public float speed = 10f;        // Qué tan rápido vuela
    public float timeToDestroy = 2f; // Cuántos segundos vive antes de desaparecer

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Esta línea es magia: le dice a Unity que destruya esta bola en 2 segundos
        Destroy(gameObject, timeToDestroy);
    }

    void Update()
    {
        // Esto lee hacia dónde está mirando la bola (1 para derecha, -1 para izquierda)
        float direction = transform.localScale.x;

        // Empuja la bola hacia esa dirección constantemente
        rb.velocity = new Vector2(speed * direction, 0);
    }
}
