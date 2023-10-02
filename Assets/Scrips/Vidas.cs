using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Sebastian Estupiñan Sanchez
public class Vidas : MonoBehaviour
{
    /// <summary>
    /// Método llamado cuando un objeto entra en el colisionador de este objeto.
    /// Accede al GameManager a través de su instancia Singleton para intentar recuperar una vida.
    /// </summary>
    /// <param name="collision">El colisionador del objeto que entra en contacto con este objeto.</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Accede al GameManager a través de su instancia Singleton para intentar recuperar una vida
        bool vidaRecuperada = GameManager.Instance.RecuperarVida();

        if (vidaRecuperada)
        {
            // Destruye este objeto si se recuperó una vida con éxito
            Destroy(this.gameObject);
        }
        else
        {
            // Maneja el caso en el que no se pudo recuperar una vida (por ejemplo, todas las vidas están llenas)
            // Puedes agregar aquí cualquier acción que desees realizar en caso de que no se recupere una vida.
            Debug.Log("Todas las vidas están llenas. No se pudo recuperar una vida.");
        }
    }
}
