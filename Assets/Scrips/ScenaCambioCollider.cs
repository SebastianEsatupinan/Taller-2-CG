using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenaCambioCollider : MonoBehaviour
{
    [SerializeField] private string nombreDeLaEscenaACargar; // Esta variable ser� visible en el Inspector y te permitir� seleccionar la escena a cargar.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que entra es el jugador
        if (collision.CompareTag("Player"))
        {
            // Muestra un mensaje de depuraci�n en la consola indicando que saliste del nivel
            Debug.Log("Saliste del nivel");

            // Carga la escena con el nombre especificado en el Inspector
            SceneManager.LoadScene(nombreDeLaEscenaACargar);
        }
    }
}
