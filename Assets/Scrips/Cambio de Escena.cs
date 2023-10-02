using UnityEngine.SceneManagement;
using UnityEngine;

// Sebastian Estupiñan Sanchez
public class MenuInicial : MonoBehaviour
{
    /// <summary>
    /// Método que se llama cuando el botón "Jugar" es presionado. Carga la siguiente escena en el índice de la escena actual.
    /// </summary>
    public void Jugar()
    {
        // Llama a la siguiente escena en el índice de la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// Método que se llama cuando el botón "Salir" es presionado. Cierra la aplicación.
    /// </summary>
    public void Salir()
    {
        // Sale de la aplicación
        Debug.Log("Salir...:");
        Application.Quit();
    }
}