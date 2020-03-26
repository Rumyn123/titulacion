using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//InputController es heredada de MonoBehaviur, osea que se puede comportar como inputcontroller o monobehauvior
[RequireComponent(typeof(Atributos))] 
public class InputPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public float ejeHorizontal{get; private set;}//HideInInspector es un atributo para ocultar la variable
    [HideInInspector] public float ejeVertical {get; private set;}
    [HideInInspector] public bool atacar       {get; private set;}
    [HideInInspector] public bool habilidad1   {get; private set;}
    [HideInInspector] public bool habilidad2   {get; private set;}
    [HideInInspector] public bool inventario   {get; private set;}
    [HideInInspector] public bool interactuar  {get; private set;}


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //atacar = Input.GetKeyDown(KeyCode.Z); este no se recomienda porque se cambian los botones en el codigo
        // el de abajo se recomienda porque se modifica desde unity
        atacar = Input.GetButtonDown("Atacar");
        habilidad1 = Input.GetButtonDown("Habilidad1");
        habilidad2 = Input.GetButtonDown("Habilidad2");
        inventario = Input.GetButtonDown("Inventario");
        interactuar = Input.GetButtonDown("Interactuar");
        ejeHorizontal = Input.GetAxis("Horizontal");
        ejeVertical = Input.GetAxis("Vertical");
        //Debug.Log("Vertical es: " + ejeVertical + " y Horizontal es: " + ejeHorizontal);
    }
}
