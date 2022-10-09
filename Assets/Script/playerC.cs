using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class playerC : MonoBehaviour
{ 
    Animator animator;
    Rigidbody2D rb;

    [Header("Opciones Jugador: ")]
    public TextMeshProUGUI puntaje;
    public float salto;
    public float abajo;

    [Header("Ataque jugador: ")]
    public Transform controladorAtaque;
    public float radio;
    public float dañoAtaque;
    public float tiempoEntre;
    private float tiempoSiguiente;

    private int puntos = 0;
    private bool puedeSaltar;

    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
    }

    void Update()
    {
        ControlPuntos();
        Movimiento();
        Ataque();
    }

    private void Movimiento()
    {
     
        if (Input.GetKeyDown(KeyCode.W) && puedeSaltar)
        {
            rb.AddForce(Vector2.up * salto, ForceMode2D.Impulse);
            puedeSaltar = false;
            animator.SetTrigger("Jump");
            animator.SetBool("Down", true);

        }
        if (Input.GetKeyDown(KeyCode.S) && !puedeSaltar)
        {
            rb.AddForce(Vector2.up * abajo, ForceMode2D.Impulse);

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
                collisionador.transform.GetComponent<Enemigo>().Daño(dañoAtaque);
            }
        }
    }

    private void ControlPuntos()
    {
        if(puntos == 100)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
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
            animator.SetBool("Down", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Libro"))
        {
            Destroy(collision.gameObject);
            puntos += 5;
            Texto();
        }
    }

    private void Texto()
    {
        puntaje.text = puntos.ToString();
    }
}
