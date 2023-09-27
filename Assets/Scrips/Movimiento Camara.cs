using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCamara : MonoBehaviour
{
    public GameObject Jugador;


    private void LateUpdate()
    {
        Vector3 newPosition = transform.position;
        newPosition.x = Jugador.transform.position.x;
        newPosition.y = Jugador.transform.position.y;
        transform.position = newPosition;
    }
}
