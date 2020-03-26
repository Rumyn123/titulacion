using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private float velocidad; //Unidades de espacio global por segundo [m/s] el serializeField es un atributo para mostrar

    private InputPlayer inputJugador;
    private float horizontal;
    private float vertical;
    private Rigidbody2D miRigidbody2D; //CamelCase es poner en miniscula la primer palabra
    private Animator animador;
    private SpriteRenderer miSprite;
    private int correrHashCode;
    private Atributos atributosJugador;
    private Atacante atacante;
    // Start is called before the first frame update
    void Start()
    {
        atacante = GetComponent<Atacante>();
        atributosJugador = GetComponent<Atributos>();
        inputJugador = GetComponent<InputPlayer>(); // Buscará dentro del game object hasta encontarr un componente de tipo INputPlayer
        miRigidbody2D = GetComponent<Rigidbody2D>(); //RigidBody del GameObject
        animador = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
        correrHashCode = Animator.StringToHash("Corriendo");
    }

    // Update is called once per frame

    private void Update() //la logica va en update
    {
        horizontal = inputJugador.ejeHorizontal;
        vertical = inputJugador.ejeVertical;
        //VoltearSprite();

        if (horizontal != 0 || vertical != 0)
        {
            SetearXTAnimador();
            animador.SetBool(correrHashCode, true);
        } else
        {
            animador.SetBool(correrHashCode, false);
        }

        if (Input.GetButtonDown("Atacar"))
        {
            atacante.Atacar(new Vector2(horizontal, vertical), atributosJugador.ataque);
        }
    }

    private void VoltearSprite()
    {
        if (horizontal > 0 && Mathf.Abs(vertical) < Mathf.Abs(horizontal))
        {
            miSprite.flipX = false;
        }
        else if (horizontal != 0)
        {
            miSprite.flipX = true;
        }
    }

    private void SetearXTAnimador()
    {
        animador.SetFloat("X", horizontal);
        animador.SetFloat("Y", vertical);
    }

    void FixedUpdate() //la fisica va en fixedUpdate
    {
        

        //Mover personaje moviendo la transformada
        //Vector2 nuevaPosicion = transformada.position+ new Vector3(velocidad * horizontal * Time.deltaTime, velocidad*vertical* Time.deltaTime, 0);
        //transformada.position = nuevaPosicion;

        //-----Movimiento----- se hace con fuerza para añadir las colisiones y masa
        //Vector2 fuerza = new Vector2(horizontal,vertical)*velocidad*Time.deltaTime;
        //miRigidbody2D.AddForce(fuerza);

        //-----Movimiento por fisicas----
        Vector2 vectorVelocidad = new Vector2(horizontal, vertical) * atributosJugador.velocidad;
        miRigidbody2D.velocity = vectorVelocidad;

    }

   
}
