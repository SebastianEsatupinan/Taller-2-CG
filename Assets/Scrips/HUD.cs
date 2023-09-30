using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI puntos;
    public GameObject[] Vidas;

    void Update()
    {
        // Accede al GameManager a través de su instancia Singleton
        puntos.text = GameManager.Instance.PuntosTotales.ToString();
    }

    public void ActualizarPuntos(int PuntosTotales)
    {
        // Accede al GameManager a través de su instancia Singleton
        puntos.text = PuntosTotales.ToString();
    }

    public void DesactivarVida(int indice)
    {
        Vidas[indice].gameObject.SetActive(false);
    }

    public void ActivarVida(int indice)
    {
        Vidas[indice].gameObject.SetActive(true);
    }
}
