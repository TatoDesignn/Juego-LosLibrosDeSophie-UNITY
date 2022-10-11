using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    Rigidbody2D rb;
    spawner2 spawn;

    [Space]
    [Header("CONTROL: ")]
    public float velocidad;
    

    private void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<spawner2>();
        velocidad += spawn.velocidad;

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * velocidad;
        Destruir();
    }

    private void Destruir()
    {
        Destroy(gameObject, 7);
    }
}
