using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoDisparo : MonoBehaviour
{
    public GameObject Player;
    public GameObject BulletPrefab;
    private float LastShoot;

    private void Update()
    {
        MirarJugador();
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

        float distance = Mathf.Abs(Player.transform.position.x - transform.position.x);
        if (distance < 1.0f && Time.time > LastShoot + 0.5f)
        {
            Shoot();
            LastShoot = Time.time;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Accede al GameManager a través de su instancia Singleton
            GameManager.Instance.PerderVida();
        }
    }

    private void Shoot()
    {

        Vector3 direcionBala;
        if (transform.localScale.x == 1.0f)
        {
            direcionBala = Vector3.right;
        }
        else
        {
            direcionBala = Vector3.left;


        }

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direcionBala * 0.1f, Quaternion.identity);
        // Voltea la escala de la bala si el personaje mira hacia la izquierda


        bullet.GetComponent<Disparo>().setDirection(direcionBala);

        // Actualiza el tiempo del último disparo

    }




}








