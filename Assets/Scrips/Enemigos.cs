using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sebastian Estupiñan Sanchez
public class Enemigos : MonoBehaviour
{
    // Referencia al objeto del jugador
    public GameObject Player;

    // Método Update se llama en cada fotograma
    private void Update()
    {
        // Llama al método para hacer que el enemigo mire hacia el jugador
        MirarJugador();
    }

    /// <summary>
    /// Hace que el enemigo mire hacia la posición del jugador.
    /// </summary>
    private void MirarJugador()
    {
        // Obtiene la dirección desde el enemigo hasta el jugador
        Vector3 direction = Player.transform.position - transform.position;

        // Si la dirección en el eje X es positiva, el jugador está a la derecha del enemigo
        if (direction.x >= 0.0f)
        {
            // Voltea la escala del enemigo en el eje X para que mire hacia la derecha
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else
        {
            // Voltea la escala del enemigo en el eje X para que mire hacia la izquierda
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
    }

    /// <summary>
    /// Método llamado cuando el enemigo colisiona con el jugador.
    /// Si el enemigo colisiona con el jugador, llama al método PerderVida() del GameManager.
    /// </summary>
    /// <param name="collision">La información sobre la colisión.</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto con el que colisiona es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Accede al GameManager a través de su instancia Singleton y llama al método PerderVida()
            GameManager.Instance.PerderVida();
        }
    }
}
