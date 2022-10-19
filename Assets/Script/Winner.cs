using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Winner : MonoBehaviour
{
    Animator sophie;
    Animator papa;
    AudioSource audio1;

    public GameObject dialogo1;
    public GameObject dialogo2;
    public GameObject boton1;
    public GameObject boton2;
    public GameObject boton3;
    public GameObject panel;
    public GameObject final;

    private void Start()
    {
        sophie = GameObject.FindGameObjectWithTag("Sophie").GetComponent<Animator>();
        papa = GameObject.FindGameObjectWithTag("Papa").GetComponent<Animator>();
        audio1 = GetComponent<AudioSource>();

        dialogo2.SetActive(false);
        boton2.SetActive(false);
        boton3.SetActive(false);
        panel.SetActive(false);
        final.SetActive(false);
    }

    public void Pasar()
    {
        audio1.Play();
        dialogo1.SetActive(false);
        dialogo2.SetActive(true);

        Destroy(boton1);

        boton2.SetActive(true);
        boton3.SetActive(true);
    }

    public void Si()
    {
        audio1.Play();
        StartCoroutine(Cambio2());
    }

    private IEnumerator Cambio()
    {
        Destroy(boton2);
        Destroy(boton3);
        Destroy(dialogo2);
        papa.SetTrigger("Pasar");

        yield return new WaitForSeconds(1);

        sophie.SetTrigger("si");

        yield return new WaitForSeconds(0.5f);

        panel.SetActive(true);

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(4);

    }

    private IEnumerator Cambio2()
    {
        panel.SetActive(true);

        yield return new WaitForSeconds(0.3f);

        final.SetActive(true);

        yield return new WaitForSeconds(35);

        SceneManager.LoadScene(0);
    }

    public void No()
    {
        audio1.Play();
        StartCoroutine(Cambio());
    }
}
