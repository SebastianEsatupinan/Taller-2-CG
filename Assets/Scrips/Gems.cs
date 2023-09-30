using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gems : MonoBehaviour
{
    public int valor = 1;
    public AudioClip MonedaFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Debug.Log("Colisión con las gemas");

            // Accede al GameManager a través de su instancia Singleton
            GameManager.Instance.SumarPuntos(valor);

            // Reproduce el sonido de la moneda si lo deseas
            if (MonedaFX != null)
            {
                AudioSource.PlayClipAtPoint(MonedaFX, transform.position);
            }

            Destroy(this.gameObject);
        }
    }
}
