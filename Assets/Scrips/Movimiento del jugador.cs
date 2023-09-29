using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

public class Movimientodeljugador : MonoBehaviour
{
    //Variables Modificables desde el ispector
    public float JumpForce;
    public int JumpMax;
    public float velocidad;
    public LayerMask CapaSuelo;
    public GameObject BulletPrefab;

    //Variables De uso privado
    private Rigidbody2D RG2D;
    private CapsuleCollider2D Capsule;
    
    private float Horizontal;
    private int SaltosRestantes; 
    private Animator Animator;

    

    void Start()
    {
        RG2D = GetComponent<Rigidbody2D>();
        Capsule = GetComponent<CapsuleCollider2D>();
        SaltosRestantes = JumpMax;
        Animator = GetComponent<Animator>();
    }


    void Update()
    {
        //Llamado de Metodos necesarios
        Moverse();
        Jump();
        Shoot();
    }

    private void Moverse()
    {
        //Funcion Para moverse de Izquierda a Derecha
        Horizontal = Input.GetAxisRaw("Horizontal") * velocidad;

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (Horizontal > 0.0f) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        Animator.SetBool("EstaCorriendo", Horizontal != 0.0f);
    }

    private bool EstaEnSuelo()
    {
        // Detecta Si esta en el Suelo o no

        RaycastHit2D raycastHit = Physics2D.CapsuleCast(
        Capsule.bounds.center,             // Centro del CapsuleCollider2D
        Capsule.bounds.size,               // Tamaño del CapsuleCollider2D
        CapsuleDirection2D.Vertical,       // Dirección vertical del CapsuleCollider2D
        0f,                                // Ángulo de rotación
        Vector2.down,                      // Dirección hacia abajo
        0.0002f,                            // Longitud del rayo
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

    private void Shoot()
    {
        //Metodo de Disparo
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 direcionBala;
            if (transform.localScale.x == 1.0f)
            {
                direcionBala = Vector3.right;
            }
            else
            {
                direcionBala = Vector3.left;


            }

            GameObject bullet = Instantiate(BulletPrefab, transform.position + direcionBala * 0.1f, Quaternion.identity);
            // Voltea la escala de la bala si el personaje mira hacia la izquierda
            if (transform.localScale.x == -1.0f)
            {
                Vector3 newScale = bullet.transform.localScale;
                newScale.x *= -1; // Invierte la escala en el eje X
                bullet.transform.localScale = newScale;
            }

            bullet.GetComponent<Disparo>().setDirection(direcionBala);
        }
    }

    private void FixedUpdate()
    {
        RG2D.velocity = new Vector2(Horizontal, RG2D.velocity.y);
    }

}
