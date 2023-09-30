using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour
{
    public int valor = 1;
    public GameManager manager;
    public AudioClip MonedaFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Colisión con al gemas");
            manager.SumarPuntos(valor);
            Destroy(this.gameObject);
        }

    }
}
