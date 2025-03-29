using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public int veneno = 1; // Puntos de vida que quita.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Añadir lógica de recolección (ej: aumentar puntuación).
            GameManager.Instance.PlayerDeath();
            Destroy(gameObject); // Opcional: destruir el objeto al recolectar.
        }
    }
}
