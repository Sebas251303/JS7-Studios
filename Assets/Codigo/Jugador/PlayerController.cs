using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;
    public float jumpForce = 12f;

    [Header("Detección Suelo")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.08f;
    public LayerMask groundLayer;

    [Header("Fuego")]
    public Transform firePoint;
    public GameObject fireballPrefab;

    private Rigidbody2D rb;
    private Animator animator;
    private int jumpCount;
    private bool isGrounded;
    private bool isCrouching;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CheckStatus();
        Mover();
        Saltar();
        Atacar();
    }

    void CheckStatus()
    {
        // Revisa si estamos tocando el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        // Detectar si estamos agachados (Flecha abajo o S)
        isCrouching = isGrounded && (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow));
        animator.SetBool("isCrouching", isCrouching);
    }

    void Mover()
    {
        // Si estamos agachados, no nos movemos hacia los lados
        if (isCrouching)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetFloat("Speed", 0);
            return;
        }

        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Voltear al personaje según la dirección
        if (moveInput != 0)
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);

        animator.SetFloat("Speed", Mathf.Abs(moveInput));
    }

    void Saltar()
    {
        // Solo saltamos si NO estamos agachados
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2 && !isCrouching)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
            animator.SetTrigger("Jump");
        }
        if (isGrounded) jumpCount = 0;
    }

    void Atacar()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            animator.SetTrigger("Attack");

            if (fireballPrefab != null && firePoint != null)
            {
                GameObject proyectil = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
                proyectil.transform.localScale = transform.localScale;
            }
        }
    }

    public void TakeDamage(int amount)
    {
        SaludJugador salud = GetComponent<SaludJugador>();
        if (salud != null) salud.RecibirDanio();
    }
}