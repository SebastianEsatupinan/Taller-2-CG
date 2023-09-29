using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    public float velocidadBala;
    private Vector2 DirecionBala;

    public float tiempoDeVida = 2.0f; // Duración en segundos
    private float tiempoTranscurrido = 0.0f; // El tiempo que ha pasado desde que se instanció la bala


    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        Rigidbody2D.velocity = DirecionBala * velocidadBala;

        // Incrementa el tiempo transcurrido
        tiempoTranscurrido += Time.deltaTime;

        // Si el tiempo transcurrido es mayor o igual al tiempo de vida, destruye la bala
        if (tiempoTranscurrido >= tiempoDeVida)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Detecta una colisión con el entorno
        if (collision.gameObject.layer == LayerMask.NameToLayer("Suelo"))
        {
            Destroy(gameObject);
        }
    }

    public void setDirection(Vector2 direction)
    {
        DirecionBala = direction;
    }

}
