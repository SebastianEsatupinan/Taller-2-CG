using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigos : MonoBehaviour
{
    public GameObject Player;
    public GameManager manager;

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
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            manager.PerderVida();
        }
    }
}
