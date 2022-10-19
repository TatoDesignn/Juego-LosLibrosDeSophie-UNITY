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
    Transition2 trans;
    AudioSource audio1;

    [Header("Opciones Jugador: ")]
    public TextMeshProUGUI puntaje;
    public float salto;
    public float abajo;
    
    [Space]
    [Header("Ataque jugador: ")]
    public Transform controladorAtaque;
    public float radio;
    public float dañoAtaque;
    public float tiempoEntre;
    private float tiempoSiguiente;

    [Space]
    [Header("Sonidos: ")]
    [SerializeField] private AudioClip Duende;
    [SerializeField] private AudioClip tronco;
    [SerializeField] private AudioClip GolpeS;
    [SerializeField] private AudioClip punticos;

    private int pausa;
    public int puntos = 0;
    private bool puedeSaltar;

    void Start()
    {
        trans = GameObject.FindGameObjectWithTag("Transicion").GetComponent<Transition2>();
        audio1 = GetComponent<AudioSource>();

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        pausa = 0;
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

        if (Input.GetKeyDown(KeyCode.Escape) && pausa == 0)
        {
            Time.timeScale = 0;
            pausa += 1;
        }

        if(Input.GetKeyDown(KeyCode.Escape) && pausa == 1)
        {
            Time.timeScale = 1;
            pausa = 0;
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
                audio1.PlayOneShot(GolpeS);
                collisionador.transform.GetComponent<Enemigo>().Daño(dañoAtaque);
            }
        }
    }

    private void ControlPuntos()
    {
        if(puntos == 100)
        {
            puntos = 101;
            trans.Pasar();
            Invoke("Cambio2", 1);
        }
    }

    private void Cambio()
    {
        SceneManager.LoadScene("Dead");
    }

    private void Cambio2()
    {
        SceneManager.LoadScene("Win");
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

        if(collision.collider.tag == "Enemigo")
        {
            audio1.PlayOneShot(Duende);
            animator.SetTrigger("Death");
            trans.Pasar();
            Invoke("Cambio", 1);

        }

        if(collision.collider.tag == "Tronco")
        {
            audio1.PlayOneShot(tronco);
            animator.SetTrigger("Death");
            trans.Pasar();
            Invoke("Cambio", 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Libro"))
        {
            audio1.PlayOneShot(punticos);
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
