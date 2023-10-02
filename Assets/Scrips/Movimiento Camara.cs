using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sebastian Estupi�an Sanchez
public class MovimientoCamara : MonoBehaviour
{
    // Referencia al objeto del jugador
    public GameObject Jugador;

    /// <summary>
    /// M�todo llamado en cada fotograma despu�s de que todos los objetos hayan sido procesados.
    /// Actualiza la posici�n de la c�mara para seguir al jugador en los ejes X y Y.
    /// </summary>
    private void LateUpdate()
    {
        // Obtiene la posici�n actual de la c�mara
        Vector3 newPosition = transform.position;

        // Establece la posici�n en el eje X de la c�mara igual a la posici�n en el eje X del jugador
        newPosition.x = Jugador.transform.position.x;

        // Establece la posici�n en el eje Y de la c�mara igual a la posici�n en el eje Y del jugador
        newPosition.y = Jugador.transform.position.y;

        // Actualiza la posici�n de la c�mara para seguir al jugador en los ejes X y Y
        transform.position = newPosition;
    }
}
