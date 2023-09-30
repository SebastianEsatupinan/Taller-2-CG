using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int PuntosPerdidos;
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

        if(vida == 0)
        {
            loadScene();
            puntosTotales = puntosTotales - PuntosPerdidos;
            HUD.ActualizarPuntos(puntosTotales);
        }

        HUD.DesactivarVida(vida);
    }

    public bool RecuperarVida()
    {
        if(vida == 3)
        {
            return false;
        }

        HUD.ActivarVida(vida);
        vida += 1;
        return true;
    }

    public void loadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
