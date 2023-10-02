using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public string sceneName;
    public HUD HUD;
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;
    private int vida = 3;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SumarPuntos(int puntosAsumar)
    {
        puntosTotales = puntosTotales + puntosAsumar;
        HUD.ActualizarPuntos(puntosTotales);
        Debug.Log("Los puntos actuales son: " + puntosTotales);
    }

    public void PerderVida()
    {
        vida -= 1;

        if (vida == 0)
        {
            SceneManager.LoadScene(sceneName);
            HUD.ActualizarPuntos(puntosTotales);
        }

        HUD.DesactivarVida(vida);
    }

    public void MuerteSubita()
    {
        vida = 0; // Establece la vida del jugador a 0
        SceneManager.LoadScene(sceneName);
    }

    public bool RecuperarVida()
    {
        if (vida == 3)
        {
            return false;
        }

        HUD.ActivarVida(vida);
        vida += 1;
        return true;
    }

    public void ResetearPuntos()
    {
        puntosTotales -= 100;
        HUD.ActualizarPuntos(puntosTotales);
    }

    public void loadScene()
    {
        ResetearPuntos();
        SceneManager.LoadScene(sceneName);
    }
}
