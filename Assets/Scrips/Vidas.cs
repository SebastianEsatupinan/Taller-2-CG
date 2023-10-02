using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Accede al GameManager a través de su instancia Singleton
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
