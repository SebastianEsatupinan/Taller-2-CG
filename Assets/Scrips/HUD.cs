using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{

    public TextMeshProUGUI puntos;
    public GameObject[] Vidas;

    void Start()
    {
        Debug.Log("HUD Start");
        if (puntos == null)
        {
            Debug.LogError("puntos es null en Start");
        }
    }


    void Update()
    {
        // Accede al GameManager a trav駸 de su instancia Singleton
        puntos.text = GameManager.Instance.PuntosTotales.ToString();
    }

    public void ActualizarPuntos(int PuntosTotales)
    {
        // Accede al GameManager a trav駸 de su instancia Singleton
        puntos.text = PuntosTotales.ToString();
    }

    public void DesactivarVida(int indice)
    {
        if (Vidas != null && indice >= 0 && indice < Vidas.Length)
        {
            Vidas[indice].gameObject.SetActive(false);
        }
        else
        {
            Debug.LogError("ﾍndice fuera de rango o array Vidas no inicializado correctamente.");
        }
    }

    public void ActivarVida(int indice)
    {
        if (Vidas != null && indice >= 0 && indice < Vidas.Length && Vidas[indice] != null)
        {
            Vidas[indice].gameObject.SetActive(true);
        }
        else
        {
            // Ade una comprobaci adicional para asegurarte de que Vidas[indice] no sea null
            if (Vidas == null)
            {
                Debug.LogError("El array Vidas no est・inicializado.");
            }
            else if (indice < 0 || indice >= Vidas.Length)
            {
                Debug.LogError("ﾍndice fuera de rango: " + indice);
            }
            else if (Vidas[indice] == null)
            {
                Debug.LogError("El objeto en Vidas[" + indice + "] es null.");
            }
            else
            {
                Debug.LogError("Error desconocido al activar la vida.");
            }
        }
    }
}  
