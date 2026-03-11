using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 12f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private int jumpCount = 0;
    private int maxJumps = 2;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (isGrounded)
        {
            jumpCount = 0;
        }

        if (Input.GetButtonDown("Jump") && jumpCount < maxJumps)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
        }
    }
}