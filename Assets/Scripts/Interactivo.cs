using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactivo : MonoBehaviour
{
    private Collider2D miColisionador;
    public UnityEvent OnInteraction;

    private void Start()
    {
        miColisionador = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnInteraction?.Invoke(); //Con el signo de interrogación, no va a invocar nada si está vacio, esto permite mejor fluidez de memoria
    }
}
