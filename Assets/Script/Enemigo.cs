using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{

    public float vidaUno;

    public void Daño(float daño)
    {

        vidaUno -= daño;


        if (vidaUno <= 0)
        {
            Destroy(gameObject);
        }
    }
}
