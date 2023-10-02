using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigosDisparo : MonoBehaviour
{
    public GameObject Player;
    public GameObject BulletPrefab;
    public float tiempoDeEsperaEntreDisparos = 2.0f;
    private float tiempoUltimoDisparo = 0.0f;

    void Update()
    {
        MirarJugador();
        Disparar();
    }

    private void MirarJugador()
    {
        Vector3 direction = Player.transform.position - transform.position;

        if (direction.x >= 0.0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
        else
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
    }

    private void Disparar()
    {
        if (Time.time - tiempoUltimoDisparo >= tiempoDeEsperaEntreDisparos)
        {
            Vector3 direccionBala = transform.localScale.x == 1.0f ? Vector3.right : Vector3.left;
            GameObject bullet = Instantiate(BulletPrefab, transform.position + direccionBala * 0.1f, Quaternion.identity);

            // Voltea la escala de la bala si el enemigo mira hacia la izquierda
            if (transform.localScale.x == -1.0f)
            {
                Vector3 newScale = bullet.transform.localScale;
                newScale.x *= -1; // Invierte la escala en el eje X
                bullet.transform.localScale = newScale;
            }

            bullet.GetComponent<Disparo>().setDirection(direccionBala);
            tiempoUltimoDisparo = Time.time;
        }
    }

    // Resto del código
}
