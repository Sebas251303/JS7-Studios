using UnityEngine;

public class MiniJefes : MonoBehaviour
{
    public float speed = 2f;
    public float detectionRadius = 5.0f;
    public Transform player;
    private Rigidbody2D rb;
    private Vector2 movement;
    private bool JugadorVivo;
    public bool enMovimiento;
    public int damage = 1;
    public Animator anim;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRadius)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            
            movement = new Vector2(direction.x, 0);

            Vector3 escala = transform.localScale;

<<<<<<< HEAD
        if (direction.x < 0)
        {
            escala.x = Mathf.Abs(escala.x); 
=======
            float distancia = Mathf.Abs(player.position.x - transform.position.x);

            if (anim != null)
            {
                anim.SetFloat("Speed", distancia);
            }

            Vector3 escala = transform.localScale;

            if (player.position.x > transform.position.x)
                escala.x = -Mathf.Abs(escala.x);
            else
                escala.x = Mathf.Abs(escala.x);

            transform.localScale = escala;
>>>>>>> origin/main
        }
        else if (direction.x > 0)
        {
            escala.x = -Mathf.Abs(escala.x); 
        }

        transform.localScale = escala;

            enMovimiento = true;
        }
        else
        {
            movement = Vector2.zero;
            enMovimiento = false;
        }

        rb.MovePosition(rb.position + movement * speed * Time.deltaTime);

        anim.SetBool("enMovimiento", enMovimiento);
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