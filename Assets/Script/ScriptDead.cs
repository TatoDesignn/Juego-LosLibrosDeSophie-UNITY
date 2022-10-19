using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptDead : MonoBehaviour
{
    AudioSource audio1;

    private void Start()
    {
        audio1 = GetComponent<AudioSource>();
    }

    public void Jugar()
    {
        audio1.Play();
        SceneManager.LoadScene("Juego");
    }

    public void Exit()
    {
        audio1.Play();
        Application.Quit();
    }
}
