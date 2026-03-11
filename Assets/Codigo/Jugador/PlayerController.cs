using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed = 5f;
    public float jumpForce = 12f;

    [Header("Doble Salto")]
    public int maxJumps = 2;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Animator animator;

    private int jumpCount;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Move();
        HandleJump();
        CheckGround();
        UpdateAnimations();
    }

    void Move()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (moveInput != 0)
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);
    }

    void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;

            animator.SetTrigger("Jump");
            animator.SetBool("isGrounded", false);
        }
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(
            groundCheck.position,
            groundCheckRadius,
            groundLayer
        );

        if (isGrounded)
        {
            jumpCount = 0;
        }
    }

    void UpdateAnimations()
    {
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }
}
