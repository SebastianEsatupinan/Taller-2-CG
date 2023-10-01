using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recolectables : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !RecolectablesManager.Instance.HaSidoRecolectado(gameObject))
        {
            RecolectablesManager.Instance.RegistrarRecolectable(gameObject);
            // Realizar acciones cuando el objeto es recolectado, como sumar puntos o desaparecer
            gameObject.SetActive(false); // Desactiva el objeto, por ejemplo
        }
    }
}
