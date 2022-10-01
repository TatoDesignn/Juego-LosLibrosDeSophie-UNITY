using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class playerC : MonoBehaviour
{ 
    Animator animator;
    Rigidbody2D rb;

    [Header("Opciones Jugador: ")]
    public float velocidad;
    public float salto;

    [Header("Ataque jugador: ")]
    public Transform controladorAtaque;
    public float radio;
    public float dañoAtaque;
    public float tiempoEntre;
    private float tiempoSiguiente;

    private bool controlM;
    private bool moving;
    private bool puedeSaltar;

    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movimiento();
        Ataque();
    }

    private void Movimiento()
    {
        Vector2 newVelocity;
        
        newVelocity.x = velocidad;
        newVelocity.y = rb.velocity.y;

        rb.velocity = newVelocity;

        if (controlM)
        {
            if (moving = rb.velocity.x > 0)
            {
                animator.SetBool("Run", moving);
            }
        }
     
        if (Input.GetKeyDown(KeyCode.W) && puedeSaltar)
        {
            rb.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
            puedeSaltar = false;
            animator.SetTrigger("Jump");
            animator.SetBool("Down", true);
            moving = false;
            controlM = false;
        }

    }

    public void Ataque()
    {
        if(tiempoSiguiente > 0)
        {
            tiempoSiguiente -= Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space) && tiempoSiguiente <= 0)
        {
            tiempoSiguiente = tiempoEntre;
            Golpe();
        }
    }

    private void Golpe()
    {
        animator.SetTrigger("Attack");

        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorAtaque.position, radio);
        foreach (Collider2D collisionador in objetos)
        {
            if (collisionador.CompareTag("Enemigo"))
            {
                //collisionador.transform.GetComponent<enemigoC_Fuego>().Daño(dañoGolpe);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere (controladorAtaque.position, radio);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Suelo")
        {
            puedeSaltar = true;
            controlM = true;
            animator.SetBool("Down", false);
        }
    }
}
