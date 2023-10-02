using UnityEngine.SceneManagement;
using UnityEngine;

// Sebastian Estupi�an Sanchez
public class MenuInicial : MonoBehaviour
{
    /// <summary>
    /// M�todo que se llama cuando el bot�n "Jugar" es presionado. Carga la siguiente escena en el �ndice de la escena actual.
    /// </summary>
    public void Jugar()
    {
        // Llama a la siguiente escena en el �ndice de la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /// <summary>
    /// M�todo que se llama cuando el bot�n "Salir" es presionado. Cierra la aplicaci�n.
    /// </summary>
    public void Salir()
    {
        // Sale de la aplicaci�n
        Debug.Log("Salir...:");
        Application.Quit();
    }
}