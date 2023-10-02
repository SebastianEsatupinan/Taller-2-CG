using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sebastian Estupiñan Sanchez
public class Recolectables : MonoBehaviour
{
    /// <summary>
    /// Método llamado cuando un objeto entra en el colisionador de este objeto.
    /// Si el objeto que entra es el jugador y este recolectable aún no ha sido recolectado,
    /// lo registra en el RecolectablesManager y realiza acciones como sumar puntos o desaparecer el objeto.
    /// </summary>
    /// <param name="other">El colisionador del objeto que entra en contacto con este objeto.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra es el jugador y si este recolectable aún no ha sido recolectado
        if (other.CompareTag("Player") && !RecolectablesManager.Instance.HaSidoRecolectado(gameObject))
        {
            // Registra este objeto como recolectable en el RecolectablesManager
            RecolectablesManager.Instance.RegistrarRecolectable(gameObject);

            // Realiza acciones cuando el objeto es recolectado, como sumar puntos o desaparecer
            // En este caso, desactiva el objeto
            gameObject.SetActive(false);
        }
    }
}
