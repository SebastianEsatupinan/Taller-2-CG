using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour
{
    public GameManager manager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        manager.RecuperarVida();
        Destroy(this.gameObject);
    }
}
