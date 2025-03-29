using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{   
    public GameObject ObjetoAmover;
    public Transform pointA;  // Primer punto de la plataforma
    public Transform pointB;  // Segundo punto de la plataforma
    public float speed = 2f;  // Velocidad de movimiento

    private Vector3 target;   // Objetivo actual

    void Start()
    {
        target = pointB.position;  // Empieza moviéndose hacia el punto B
    }

    void Update()
    {
        // Mueve la plataforma hacia el objetivo actual
        ObjetoAmover.transform.position = Vector3.MoveTowards(ObjetoAmover.transform.position, target, speed * Time.deltaTime);

        // Cambia de objetivo cuando se llega a los puntos
        if (ObjetoAmover.transform.position == pointB.position)
        {
            target = pointA.position;
        }

        if (ObjetoAmover.transform.position == pointA.position)
        {
            target = pointB.position;
        }
    }

      
      
    
    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // Hacer que el jugador siga a la plataforma
            collision.transform.SetParent(transform);
            Debug.Log("Sobre");
            // Opción adicional: bloquear la rotación del jugador si lo prefieres
            // collision.transform.rotation = Quaternion.identity;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // El jugador deja de seguir a la plataforma
            collision.transform.SetParent(null);
        }
    }*/
}
