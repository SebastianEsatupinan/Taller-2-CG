using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

// Sebastian Estupiñan Sanchez
public class GameManager : MonoBehaviour
{
    // Instancia única de GameManager para el patrón Singleton
    public static GameManager Instance { get; private set; }

    public LevelManager LevelManager;

    // Referencia al HUD para actualizar los puntos y las vidas
    public HUD HUD;

    // Propiedad para obtener los puntos totales
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;

    // Vidas del jugador
    private int vida = 3;

    // Método Awake se llama cuando se crea la instancia del script
    private void Awake()
    {
        // Si no hay otra instancia de GameManager, establece esta como la instancia única y no se destruye al cargar nuevas escenas
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            vida = 3; // Asegúrate de inicializar las vidas aquí
        }
        else
        {
            // Si ya hay otra instancia, destruye esta para mantener solo una instancia del script
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Suma puntos al total y actualiza el HUD con el nuevo valor de puntos.
    /// </summary>
    /// <param name="puntosASumar">La cantidad de puntos que se sumarán al total.</param>
    public void SumarPuntos(int puntosASumar)
    {
        // Suma los puntos al total
        puntosTotales += puntosASumar;

        // Actualiza el HUD con el nuevo valor de puntos
        HUD.ActualizarPuntos(puntosTotales);

        // Muestra un mensaje de depuración en la consola indicando los puntos actuales
        Debug.Log("Los puntos actuales son: " + puntosTotales);
    }

    /// <summary>
    /// Reduce una vida del jugador y maneja la lógica cuando el jugador se queda sin vidas.
    /// </summary>
    public void PerderVida()
    {
        // Reduce una vida del jugador
        vida--;

        // Si el jugador se queda sin vidas, carga la escena y actualiza el HUD con los puntos actuales
        if (vida <= 0)
        {
            {
               ResetearPuntos();
               LevelManager.ReiniciarNivel();
            }
        }

        // Desactiva el objeto de vida correspondiente en el HUD
        HUD.DesactivarVida(vida);
    }

    /// <summary>
    /// Intenta recuperar una vida para el jugador. Si ya tiene 3 vidas, retorna false.
    /// </summary>
    /// <returns>True si se pudo recuperar una vida, false si ya tiene 3 vidas.</returns>
    public bool RecuperarVida()
    {
        // Verifica si el jugador ya tiene 3 vidas
        if (vida >= 3)
        {
            // Si ya tiene 3 vidas, retorna false
            return false;
        }

        // Activa el objeto de vida correspondiente en el HUD
        HUD.ActivarVida(vida);

        // Aumenta una vida al jugador
        vida++;

        // Retorna true para indicar que se pudo recuperar una vida
        return true;
    }

    /// <summary>
    /// Reduce 100 puntos del total y actualiza el HUD con el nuevo valor de puntos.
    /// </summary>
    public void ResetearPuntos()
    {
        // Reduce 100 puntos del total
        puntosTotales -= 100;

        // Actualiza el HUD con el nuevo valor de puntos
        HUD.ActualizarPuntos(puntosTotales);
    }

    public void ReiniciarVidas()
    {
        vida = 3;
        HUD.ReiniciarVidas(); // Llama a un método en el HUD para reiniciar las imágenes de las vidas
    }


}
