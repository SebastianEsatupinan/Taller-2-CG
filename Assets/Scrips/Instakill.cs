using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instakill : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    /// <summary>
    /// M�todo llamado cuando un objeto entra en el colisionador de este objeto.
    /// Si el objeto que entra es el jugador, muestra un mensaje de depuraci�n y llama al m�todo ReiniciarNivel del LevelManager.
    /// </summary>
    /// <param name="collision">El colisionador del objeto que entra en contacto con este objeto.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelManager.ReiniciarNivel();
    }
}
