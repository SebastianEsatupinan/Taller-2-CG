using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] public string nombreEscena;
    public void ReiniciarNivel()
    {
        SceneManager.LoadScene(nombreEscena);
        GameManager.Instance.ReiniciarVidas();
    }
}
