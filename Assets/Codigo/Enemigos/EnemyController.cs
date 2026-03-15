using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyController : MonoBehaviour

{

    public Transform player;

    public float detectionRadius = 5.0f;

    public float speed = 2.0f;

    private Rigidbody2D rb;

    private Vector2 movement;

    private bool JugadorVivo;

    void Start()

    {
        JugadorVivo = true;
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(JugadorVivo)
        {
            Movimiento();
        }
    }

    private void Movimiento()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRadius)
        {
            Vector2 direction = (player.position - transform.position).normalized;

            movement = new Vector2(direction.x, 0);
            //  correcion de la vista del enemigo
        Vector3 escala = transform.localScale;

        if (direction.x < 0)
        {
            escala.x = Mathf.Abs(escala.x); 
        }
        else if (direction.x > 0)
        {
            escala.x = -Mathf.Abs(escala.x); 
        }

        transform.localScale = escala;

        }
        else
        {
            movement = Vector2.zero;
        }

        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);
    }
     private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Vector2 direccionDanio = new Vector2(transform.position.x, 0);
            PlayerController playerScript = collision.gameObject.GetComponent<PlayerController>();
            playerScript.RecibeDanio(direccionDanio, 1);
            JugadorVivo = !playerScript.muerto;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }

}