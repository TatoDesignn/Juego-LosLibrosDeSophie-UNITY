using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimiento : MonoBehaviour
{
    Rigidbody2D rb;

    [Space]
    [Header("CONTROL: ")]
    public float velocidad;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.left * velocidad;
    }

    void Update()
    {
        
    }
}
