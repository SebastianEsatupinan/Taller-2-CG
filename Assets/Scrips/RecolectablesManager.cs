using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecolectablesManager : MonoBehaviour
{
    public static RecolectablesManager Instance { get; private set; }

    private HashSet<GameObject> objetosRecolectados;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            objetosRecolectados = new HashSet<GameObject>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegistrarRecolectable(GameObject recolectable)
    {
        objetosRecolectados.Add(recolectable);
    }

    public bool HaSidoRecolectado(GameObject recolectable)
    {
        return objetosRecolectados.Contains(recolectable);
    }
}
