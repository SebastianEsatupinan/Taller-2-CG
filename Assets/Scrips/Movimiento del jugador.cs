using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Movimientodeljugador : MonoBehaviour
{
    //Variables Modificables desde el ispector
    public float JumpForce;
    public int JumpMax;
    public float velocidad;
    public LayerMask CapaSuelo;

    //Variables De uso privado
    private Rigidbody2D RG2D;
    private CapsuleCollider2D Capsule;
    
    private float Horizontal;
    private int SaltosRestantes; 
    //private Animator Animator;



    void Start()
    {
        RG2D = GetComponent<Rigidbody2D>();
        Capsule = GetComponent<CapsuleCollider2D>();
        SaltosRestantes = JumpMax;
        //Animator = GetComponent<Animator>();
    }


    void Update()
    {
        //Llamado de Metodos necesarios
        Moverse();
        Jump();
    }

    private void Moverse()
    {
        //Funcion Para moverse de Izquierda a Derecha
        Horizontal = Input.GetAxisRaw("Horizontal") * velocidad;

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        //Animator.SetBool("running", Horizontal != 0.0f);
    }

    private bool EstaEnSuelo()
    {
        // Detecta Si esta en el Suelo o no

        RaycastHit2D raycastHit = Physics2D.CapsuleCast(
        Capsule.bounds.center,             // Centro del CapsuleCollider2D
        Capsule.bounds.size,               // Tama�o del CapsuleCollider2D
        CapsuleDirection2D.Vertical,       // Direcci�n vertical del CapsuleCollider2D
        0f,                                // �ngulo de rotaci�n
        Vector2.down,                      // Direcci�n hacia abajo
        0.02f,                             // Longitud del rayo
        CapaSuelo);                        // Capa Que detectara el rayo

        return raycastHit.collider != null;
    }

    private void Jump()
    {
        //Funcion para Saltar
        if(EstaEnSuelo())
        {
            SaltosRestantes = JumpMax;
        }

        if (Input.GetKeyDown(KeyCode.W) && SaltosRestantes > 0)
        {
            SaltosRestantes--;
            RG2D.velocity = new Vector2(RG2D.velocity.x,0f);
            RG2D.AddForce(Vector2.up * JumpForce);
        }
    }

    private void FixedUpdate()
    {
        RG2D.velocity = new Vector2(Horizontal, RG2D.velocity.y);
    }

}
