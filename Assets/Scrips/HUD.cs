using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public GameManager gameManager;
    public TextMeshProUGUI puntos;
    public GameObject[] Vidas;

    void Update()
    {
        puntos.text = gameManager.PuntosTotales.ToString();
        
    }

    public void ActualizarPuntos(int PuntosTotales)
    {
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
