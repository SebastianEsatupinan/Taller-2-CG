using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sebastian Estupiñan Sanchez
public class MovimientoCamara : MonoBehaviour
{
    // Referencia al objeto del jugador
    public GameObject Jugador;

    /// <summary>
    /// Método llamado en cada fotograma después de que todos los objetos hayan sido procesados.
    /// Actualiza la posición de la cámara para seguir al jugador en los ejes X y Y.
    /// </summary>
    private void LateUpdate()
    {
        // Obtiene la posición actual de la cámara
        Vector3 newPosition = transform.position;

        // Establece la posición en el eje X de la cámara igual a la posición en el eje X del jugador
        newPosition.x = Jugador.transform.position.x;

        // Establece la posición en el eje Y de la cámara igual a la posición en el eje Y del jugador
        newPosition.y = Jugador.transform.position.y;

        // Actualiza la posición de la cámara para seguir al jugador en los ejes X y Y
        transform.position = newPosition;
    }
}
