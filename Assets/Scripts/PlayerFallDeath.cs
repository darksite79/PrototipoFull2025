using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallDeath : MonoBehaviour
{
    [Tooltip("Altura mínima desde la que caer para morir.")]
    public float deathHeight = -10f; // Ajusta este valor según tu nivel.

    void Update()
    {
        // Si el jugador cae por debajo de la altura límite, muere.
        /*if (transform.position.y < deathHeight)
        {
            Die();
        }*/

        float cameraBottom = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
    if (transform.position.y < cameraBottom - 2f) // 2 unidades debajo de la cámara.
    {
        Die();
    }
    }

    void Die()
    {
        Debug.Log("¡Jugador muerto por caída!");
        
        // 1. Reiniciar el nivel o quitar una vida.
        GameManager.Instance.PlayerDeath(); // Usando el GameManager existente.
        
        // 2. Opcional: Efecto visual/sonido (ej: partículas de muerte).
        // Instantiate(deathEffect, transform.position, Quaternion.identity);
        
        // 3. Destruir el jugador (si no hay sistema de vidas).
        // Destroy(gameObject);
    }
}
