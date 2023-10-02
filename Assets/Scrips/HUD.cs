using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Sebastian Estupiñan Sanchez
public class HUD : MonoBehaviour
{
    // Referencia al componente TextMeshProUGUI para mostrar los puntos
    public TextMeshProUGUI puntos;

    // Array de objetos para representar las vidas del jugador
    public GameObject[] Vidas;

    // Método Start se llama al iniciar el juego
    void Start()
    {
        // Muestra un mensaje de depuración en la consola para indicar que el HUD ha comenzado
        Debug.Log("HUD Start");

        // Comprueba si el componente TextMeshProUGUI de puntos es nulo y muestra un error si es así
        if (puntos == null)
        {
            Debug.LogError("El componente 'puntos' es null en Start");
        }
    }

    // Método Update se llama en cada fotograma
    void Update()
    {
        // Accede al GameManager a través de su instancia Singleton y actualiza el texto de puntos con el valor actual de PuntosTotales
        puntos.text = GameManager.Instance.PuntosTotales.ToString();
    }

    /// <summary>
    /// Actualiza el texto de puntos con el valor proporcionado.
    /// </summary>
    /// <param name="PuntosTotales">El valor total de puntos a mostrar.</param>
    public void ActualizarPuntos(int PuntosTotales)
    {
        // Actualiza el texto de puntos con el valor proporcionado
        puntos.text = PuntosTotales.ToString();
    }

    /// <summary>
    /// Desactiva el objeto de vida en el índice especificado en el array de Vidas.
    /// </summary>
    /// <param name="indice">El índice del objeto de vida a desactivar.</param>
    public void DesactivarVida(int indice)
    {
        // Verifica si el array Vidas no es nulo y si el índice está dentro del rango válido
        if (Vidas != null && indice >= 0 && indice < Vidas.Length)
        {
            // Desactiva el objeto de vida en el índice especificado
            Vidas[indice].gameObject.SetActive(false);
        }
        else
        {
            // Muestra errores específicos si el array Vidas es nulo o el índice está fuera del rango válido
            if (Vidas == null)
            {
                Debug.LogError("El array Vidas no está inicializado.");
            }
            else if (indice < 0 || indice >= Vidas.Length)
            {
                Debug.LogError("Índice fuera de rango: " + indice);
            }
            else
            {
                // Muestra un mensaje de error genérico si ocurre algún otro error desconocido
                Debug.LogError("Error desconocido al desactivar la vida.");
            }
        }
    }

    /// <summary>
    /// Activa el objeto de vida en el índice especificado en el array de Vidas.
    /// </summary>
    /// <param name="indice">El índice del objeto de vida a activar.</param>
    public void ActivarVida(int indice)
    {
        // Verifica si el array Vidas no es nulo y si el índice está dentro del rango válido
        if (Vidas != null && indice >= 0 && indice < Vidas.Length && Vidas[indice] != null)
        {
            // Activa el objeto de vida en el índice especificado
            Vidas[indice].gameObject.SetActive(true);
        }
        else
        {
            // Muestra errores específicos si el array Vidas es nulo, el índice está fuera del rango válido o el objeto de vida en el índice especificado es nulo
            if (Vidas == null)
            {
                Debug.LogError("El array Vidas no está inicializado.");
            }
            else if (indice < 0 || indice >= Vidas.Length)
            {
                Debug.LogError("Índice fuera de rango: " + indice);
            }
            else if (Vidas[indice] == null)
            {
                Debug.LogError("El objeto en Vidas[" + indice + "] es null.");
            }
            else
            {
                // Muestra un mensaje de error genérico si ocurre algún otro error desconocido
                Debug.LogError("Error desconocido al activar la vida.");
            }
        }
    }
}
