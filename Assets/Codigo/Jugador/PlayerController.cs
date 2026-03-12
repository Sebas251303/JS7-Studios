using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;
    public float jumpForce = 12f;

    [Header("Doble Salto")]
    public int maxJumps = 2;

    [Header("Ground Check (Detección de Suelo)")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.05f;
    public LayerMask groundLayer;

    [Header("Ataque")]
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
        CheckGround();
        HandleCrouch();
        Move();
        HandleJump();
        HandleAttack();
        UpdateAnimations();
    }

    void HandleCrouch()
    {
        // Si tocamos el piso y presionamos Flecha Abajo o S, se agacha
        if (isGrounded && (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
        {
            isCrouching = true;
        }
        else
        {
            isCrouching = false;
        }
    }

    void Move()
    {
        // Si está agachado, detenemos su velocidad y salimos de la función para que no resbale
        if (isCrouching)
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            return;
        }

        float moveInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        // Girar personaje
        if (moveInput != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);
        }
    }

    void HandleJump()
    {
        // El "!isCrouching" evita que el dragón salte mientras está agachado
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps && !isCrouching)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;

            animator.SetTrigger("Jump");
        }
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            jumpCount = 0;
        }
    }

    void HandleAttack()
    {
        // El "!isCrouching" evita que dispare fuego si está agachado
        if (Input.GetKeyDown(KeyCode.E) && !isCrouching)
        {
            Attack();
        }
    }

    void Attack()
    {
        animator.SetTrigger("Attack");

        if (fireballPrefab != null && firePoint != null)
        {
            GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
            fireball.transform.localScale = transform.localScale;
        }
        else
        {
            Debug.LogWarning("¡Falta asignar el FirePoint o el Fireball Prefab en el Inspector!");
        }
    }

    void UpdateAnimations()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");

        // Si está agachado, forzamos el parámetro Speed a 0 para que no mueva las piernas
        if (isCrouching)
        {
            animator.SetFloat("Speed", 0);
        }
        else
        {
            animator.SetFloat("Speed", Mathf.Abs(moveInput));
        }

        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("yVelocity", rb.velocity.y);
        animator.SetBool("isCrouching", isCrouching);
    }

    // Dibuja el círculo en la escena para que lo puedas ver
    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}