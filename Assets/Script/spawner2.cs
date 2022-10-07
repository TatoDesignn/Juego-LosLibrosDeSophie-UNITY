using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner2 : MonoBehaviour
{
    public GameObject tronco;
    public GameObject enemigo;
    public GameObject libro1;

    public float tiempo;

    public float posicionX;
    public float posicionY1;
    public float posicionY2;
    public float posicionY3;

    void Start()
    {
        tronco.transform.position = new Vector2(posicionX, posicionY1);
        libro1.transform.position = new Vector2(posicionX, posicionY3);
        enemigo.transform.position = new Vector2(posicionX, posicionY2);

        Generador();
    }


    void Update()
    {
        tiempo += Time.deltaTime;
    }

    private void Generador()
    {
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
        Instantiate(libro1);
        Invoke("Generador", 3f);
    }
}
