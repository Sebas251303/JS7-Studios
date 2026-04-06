using UnityEngine;

public class MiniJefes : MonoBehaviour
{
    public float speed = 2f;
    public Transform player;
    public int damage = 1;
    public Animator anim;

    void Update()
    {
        if (player != null)
        {
            Vector3 target = player.position;
            target.y = transform.position.y;

            transform.position = Vector2.MoveTowards(
                transform.position,
                target,
                speed * Time.deltaTime
            );

            float distancia = Mathf.Abs(player.position.x - transform.position.x);

            if (anim != null)
            {
                anim.SetFloat("Speed", distancia);
            }

            if (player.position.x > transform.position.x)
                transform.localScale = new Vector3(1, 1, 1);
            else
                transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerController playerScript = collision.gameObject.GetComponent<PlayerController>();

            if (playerScript != null)
            {
                Vector2 direccion = transform.position;
                playerScript.RecibeDanio(direccion, damage);

                if (anim != null)
                {
                    anim.SetTrigger("Attack");
                }

                Debug.Log("MiniBoss hizo daño");
            }
        }
    }
}