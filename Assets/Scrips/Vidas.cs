using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Accede al GameManager a través de su instancia Singleton
        GameManager.Instance.RecuperarVida();

        // Destruye este objeto
        Destroy(this.gameObject);
    }
}
