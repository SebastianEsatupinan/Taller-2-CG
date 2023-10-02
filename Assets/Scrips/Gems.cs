using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sebastian Estupiñan Sanchez
public class Gems : MonoBehaviour
{
    // Valor de la gema cuando es recolectada
    public int valor = 1;

    // Sonido de la moneda al recolectar la gema
    public AudioClip MonedaFX;

    /// <summary>
    /// Método llamado cuando un objeto entra en el colisionador de este objeto.
    /// Si el objeto que entra es el jugador, suma puntos al GameManager, reproduce el sonido de la moneda (si está configurado)
    /// y destruye la gema.
    /// </summary>
    /// <param name="collision">El colisionador del objeto que entra en contacto con este objeto.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verifica si el objeto que entra es el jugador
        if (collision.CompareTag("Player"))
        {
            // Muestra un mensaje de depuración en la consola indicando que ha ocurrido una colisión con las gemas
            Debug.Log("Colisión con las gemas");

            // Accede al GameManager a través de su instancia Singleton y suma el valor de la gema a los puntos totales
            GameManager.Instance.SumarPuntos(valor);

            // Reproduce el sonido de la moneda si está configurado
            if (MonedaFX != null)
            {
                // Reproduce el sonido de la moneda en la posición de la gema
                AudioSource.PlayClipAtPoint(MonedaFX, transform.position);
            }

            // Destruye la gema después de ser recolectada
            Destroy(this.gameObject);
        }
    }
}
