using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// David Alejandro Perez
public class ScenaCambioCollider : MonoBehaviour
{
    /// <summary>
    /// Método llamado cuando un objeto entra en el colisionador de este objeto.
    /// Si el objeto que entra es el jugador, carga la escena con el índice 2.
    /// </summary>
    /// <param name="collision">El colisionador del objeto que entra en contacto con este objeto.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que entra es el jugador
        if (collision.CompareTag("Player"))
        {
            // Muestra un mensaje de depuración en la consola indicando que saliste del nivel
            Debug.Log("Saliste del nivel");

            // Carga la escena con el índice 2
            SceneManager.LoadScene(2);
        }
    }
}
