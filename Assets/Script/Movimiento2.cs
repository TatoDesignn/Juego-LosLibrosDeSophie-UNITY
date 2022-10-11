using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento2 : MonoBehaviour
{
    Rigidbody2D rb;
    spawner2 spawn;

    [Space]
    [Header("CONTROL: ")]
    public float velocidad;


    private float velocidadInicial;
    private float velocidad2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<spawner2>();

        velocidadInicial = spawn.velocidad2;

        Mover();
    }

    private void Update()
    {
        velocidad2 = spawn.velocidad2;

        if (velocidad2 != velocidadInicial && velocidad2 < 8)
        {
            velocidad += velocidad2;
            velocidadInicial = velocidad2;
            Mover();
        }
    }

    private void Mover()
    {
        
        rb.velocity = Vector2.left * velocidad;
    }
}
