using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaEnemigo : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
    }

    public void Hurt()
    {
        anim.SetTrigger("Hurt");
    }

    public void Smoke()
    {
        anim.SetTrigger("Smoke");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
            anim.SetTrigger("Attack");

        if (Input.GetKeyDown(KeyCode.H))
            anim.SetTrigger("Hurt");

        if (Input.GetKeyDown(KeyCode.K))
            anim.SetTrigger("Smoke");
    }
}
