using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner2 : MonoBehaviour
{
    movimiento mv;

    public GameObject tronco;
    public GameObject enemigo;
    public GameObject libro1;

    public float velocidad = 0;
    public float velocidad2 = 0;

    public float contador2;
    public float contador3;
    public float contador;

    public float posicionX;
    public float posicionY1;
    public float posicionY2;

    void Start()
    {
        contador2 = 5;
        contador3 = 7;

        mv = tronco.GetComponent<movimiento>();
        mv = enemigo.GetComponent<movimiento>();

        tronco.transform.position = new Vector2(posicionX, posicionY1);
        enemigo.transform.position = new Vector2(posicionX, posicionY2);

        Generador();
    }


    void Update()
    {

        if (contador == contador2)
        {
            contador2 += 5;
            velocidad += 0.5f;
            
        }

        if (contador == contador3)
        {
            contador3 += 7;
            velocidad2 += 0.2f;

        }
    }

    private void Generador()
    {
        contador += 1;
        int elegir = Random.Range(0, 3);

        if(elegir == 1)
        {
            Tronco();
        }
        else if(elegir == 0)
        {
            Enemigo();
        }
        else
        {
            Libro();
        }
    }

    private void Tronco()
    {
        Instantiate(tronco);
        Invoke("Generador", 3f);
        
    }

    private void Enemigo()
    {
        Instantiate(enemigo);
        Invoke("Generador", 3f);

    }

    private void Libro()
    {
        float aleatorio = Random.Range(-2.8f, 2.1f);
        libro1.transform.position = new Vector2(posicionX, aleatorio);

        Instantiate(libro1);
        Invoke("Generador", 3f);
    }
}
