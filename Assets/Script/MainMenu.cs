using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    Transition trans;
    public GameObject panel;

    void Start()
    {
        trans = panel.GetComponent<Transition>();
    }
    public void Jugar()
    {
        panel.SetActive(true); 
        trans.Transicion();
        Invoke("Jugar2", 1);
            
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
