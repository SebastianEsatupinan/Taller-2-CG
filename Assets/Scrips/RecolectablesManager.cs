using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sebastian Estupiñan Sanchez
public class RecolectablesManager : MonoBehaviour
{
    // Instancia única de RecolectablesManager para el patrón Singleton
    public static RecolectablesManager Instance { get; private set; }

    // Conjunto de objetos recolectados
    private HashSet<GameObject> objetosRecolectados;

    // Método Awake se llama cuando se crea la instancia del script
    private void Awake()
    {
        // Si no hay otra instancia de RecolectablesManager, establece esta como la instancia única
        if (Instance == null)
        {
            Instance = this;
            objetosRecolectados = new HashSet<GameObject>();
        }
        else
        {
            // Si ya hay otra instancia, destruye esta para mantener solo una instancia del script
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Registra un objeto como recolectable.
    /// </summary>
    /// <param name="recolectable">El objeto que se va a registrar como recolectable.</param>
    public void RegistrarRecolectable(GameObject recolectable)
    {
        objetosRecolectados.Add(recolectable);
    }

    /// <summary>
    /// Verifica si un objeto ha sido recolectado.
    /// </summary>
    /// <param name="recolectable">El objeto que se va a verificar si ha sido recolectado.</param>
    /// <returns>True si el objeto ha sido recolectado, false en caso contrario.</returns>
    public bool HaSidoRecolectado(GameObject recolectable)
    {
        return objetosRecolectados.Contains(recolectable);
    }
}
