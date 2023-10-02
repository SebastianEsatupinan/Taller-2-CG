using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    public float velocidadBala;
    private Vector2 DirecionBala;
    public float tiempoDeVida = 2.0f; // Duraci en segundos
    private float tiempoTranscurrido = 0.0f; // El tiempo que ha pasado desde que se instanci・la bala


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
        // Detecta una colicci con un enemigo
        if (collision.gameObject.CompareTag("Enemigos"))
        {
            // Obt駭 una referencia al GameManager
            GameManager gameManager = GameManager.Instance;

            // Suma puntos al GameManager
            gameManager.SumarPuntos(15);

            // Destruye al enemigo
            Destroy(collision.gameObject);

            // Destruye la bala
            Destroy(gameObject);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("Suelo"))
        {
            // Si colisiona con el suelo, destruye la bala
            Destroy(gameObject);
        }
    }



    public void setDirection(Vector2 direction)
    {
        DirecionBala = direction;
    }

}
