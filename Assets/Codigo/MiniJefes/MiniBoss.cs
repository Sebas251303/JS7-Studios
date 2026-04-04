using UnityEngine;

public class MiniBoss : MonoBehaviour
{
    public int health = 100;
    public float speed = 2f;
    public Transform player;

    public int damage = 1; 

    void Update()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerScript = other.GetComponent<PlayerController>();

            if (playerScript != null)
            {
                Vector2 direccion = transform.position;
                playerScript.RecibeDanio(direccion, damage);

                Debug.Log("MiniBoss hizo daño");
            }
        }
    }
}