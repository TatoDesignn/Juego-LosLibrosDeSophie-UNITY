using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    [SerializeField] private GameObject objeto1;
    [SerializeField] private GameObject objeto2;

    [SerializeField] private int tamaño = 5;
    [SerializeField] private float tiempoEntre = 2.5f;
    [SerializeField] private float posicion = 16.2f;
    [SerializeField] private float posicionX = 16.2f;
    [SerializeField] private float posicion2 = 6;

    private float tiempoSiguiente;
    private int obstaculosCuenta;
    private GameObject[] obstaculos;

    void Start()
    {
        objeto1.transform.position = new Vector2(posicionX, posicion);
        objeto2.transform.position = new Vector2(posicionX, posicion2);

        obstaculos = new GameObject[tamaño];

        Generar();
    }

    void Update()
    {
        tiempoSiguiente += Time.deltaTime;

        if(tiempoSiguiente > tiempoEntre)
        {
            Spawner();
        }
    }

    private void Generar()
    {
        for (int i = 0; i < tamaño; i++)
        {
            int aleatorio = Random.Range(0, 2);

            if (aleatorio == 0)
            {
                obstaculos[i] = Instantiate(objeto1);
                obstaculos[i].SetActive(false);
            }
            else
            {
                obstaculos[i] = Instantiate(objeto2);
                obstaculos[i].SetActive(false);
            }

        }
    }

    private void Spawner()
    {
        tiempoSiguiente = 0;

        if (!obstaculos[obstaculosCuenta].activeSelf)
        {
            obstaculos[obstaculosCuenta].SetActive(true);
            Invoke("Destruir", 2f);
        }
        
        obstaculosCuenta++;

        if(obstaculosCuenta == tamaño)
        {
            obstaculosCuenta = 0;
            
        }
    }

    private void Destruir()
    {
        Destroy(objeto1);
    }
}
