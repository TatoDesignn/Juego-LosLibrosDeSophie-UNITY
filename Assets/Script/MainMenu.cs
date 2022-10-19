using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    AudioSource audio1;
    Transition trans;

    public GameObject panel;

    void Start()
    {
        trans = panel.GetComponent<Transition>();
        audio1 = GetComponent<AudioSource>();
    }
    public void Jugar()
    {
        panel.SetActive(true); 
        trans.Transicion();
        Invoke("Jugar2", 1);
        audio1.Play();
    }

    private void Jugar2()
    {
        SceneManager.LoadScene("Juego");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
