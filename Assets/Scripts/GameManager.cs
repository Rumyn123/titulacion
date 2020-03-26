using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform playerSpawnPoint;
    public GameObject jugador;
    public static GameManager instance { get; private set; }

    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null) //Solo si la variable instancia está nula, se va a asignar el valor de la clase a la variable instancia de manera estática
        {
            instance = this;
        }
    }

    void Start()
    {
        Vector3 vector = new Vector2(-1.5f, 1.5f);
        jugador = GameObject.FindGameObjectWithTag("Player");
        jugador.transform.position = playerSpawnPoint.position + vector;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
