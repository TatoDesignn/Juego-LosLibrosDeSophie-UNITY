using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transition2 : MonoBehaviour
{
    Animator animator;

    void Start()
    {
       animator = GetComponent<Animator>(); 
    }

    public void Pasar()
    {
        animator.SetTrigger("Pasar");
    }
}
