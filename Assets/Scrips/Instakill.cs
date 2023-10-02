using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sebastian Estupiñan Sanchez
public class Instakill : MonoBehaviour
{
    /// <summary>
    /// Método llamado cuando un objeto entra en el colisionador de este objeto.
    /// Si el objeto que entra es el jugador, muestra un mensaje de depuración y llama al método MuerteSubita() del GameManager.
    /// </summary>
    /// <param name="collision">El colisionador del objeto que entra en contacto con este objeto.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que entra es el jugador
        if (collision.CompareTag("Player"))
        {
            // Muestra un mensaje de depuración en la consola
            Debug.Log("Te Caiste");

            // Llama al método MuerteSubita() del GameManager para manejar la muerte súbita del jugador
            GameManager.Instance.MuerteSubita();
        }
    }
}
