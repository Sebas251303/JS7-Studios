using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     [SerializeField] UIManager uIManager;
     
    public float velocidad = 2f;
    public int vida = 3;
    public float fuerzaSalto = 5f;
    public float fuerzaRebote = 10f;
    public float longitudRaycast = 0.1f;
    public LayerMask capaSuelo;
    public bool enSuelo;
    private bool recibiendoDanio;
    public bool muerto;
    private Rigidbody2D rb;
    public Animator anim;
    public GameObject bolaFuegoPrefab;
    public Transform puntoDisparo;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!muerto)
        {
            Movimiento();

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, longitudRaycast, capaSuelo);
            enSuelo = hit.collider != null;

            if (enSuelo && Input.GetKeyDown(KeyCode.Space) && !recibiendoDanio)
            {
                rb.AddForce(new Vector2(0f, fuerzaSalto), ForceMode2D.Impulse);
            }

            // --- TECLA DE ATAQUE ---
            if (Input.GetKeyDown(KeyCode.Z) && !recibiendoDanio)
            {
                anim.SetTrigger("Ataque");
            }
            // ------------------------------------
        }

        anim.SetBool("ensuelo", enSuelo);
        anim.SetBool("recibeDanio", recibiendoDanio);
        anim.SetBool("muerto", muerto);
    }

    // --- FUNCION QUE LLAMA EL EVENTO DE ANIMACION ---
    public void DispararBola()
    {
        if (bolaFuegoPrefab != null && puntoDisparo != null)
        {
            GameObject proyectil = Instantiate(bolaFuegoPrefab, puntoDisparo.position, puntoDisparo.rotation);
            // Hereda la escala para que salga hacia el lado correcto
            proyectil.transform.localScale = transform.localScale;
        }
    }
    // ------------------------------------------------

    public void Movimiento()
    {
        float velocidadX = Input.GetAxis("Horizontal") * Time.deltaTime * velocidad;

        anim.SetFloat("Movement", velocidadX * velocidad);

        if (velocidadX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        if (velocidadX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        Vector3 posicion = transform.position;

        if (!recibiendoDanio)
            transform.position = new Vector3(velocidadX + posicion.x, posicion.y, posicion.z);
    }

    public void RecibeDanio(Vector2 direccion, int cantDanio)
    {
        if(!recibiendoDanio)
        {
        recibiendoDanio = true;
        vida -= cantDanio;
        if(uIManager != null)
        {
            uIManager.RestaCorazones(vida);
        }
        if(vida<=0)
        {
            recibiendoDanio = true;
            vida -= cantDanio;
            if (vida <= 0)
            {
                muerto = true;
            }

            if (!muerto)
            {
                Vector2 rebote = new Vector2(transform.position.x - direccion.x, 0.2f).normalized;
                rb.AddForce(rebote * fuerzaRebote, ForceMode2D.Impulse);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PinchosNormales"))
        {
            Vector2 direccionDanio = collision.transform.position;
            RecibeDanio(direccionDanio, 1);
        }

        if (collision.gameObject.CompareTag("Pinchos_Insta_Kill"))
        {
            muerto = true;
        }
    }

    public void DesactivaDanio()
    {
        recibiendoDanio = false;
        rb.velocity = Vector2.zero;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * longitudRaycast);
    }
}