using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenaCambioCollider : MonoBehaviour
{
    public GameManager manager;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            Debug.Log("Saliste del nivel");
            SceneManager.LoadScene(2);

        }
    }

}
