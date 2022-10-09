using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    Animator animator;
    public float vidaUno;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void Daño(float daño)
    {

        vidaUno -= daño;


        if (vidaUno <= 0)
        {
            animator.SetTrigger("Muerte");
            Destroy(gameObject, 0.8f);
        }
    }
}
