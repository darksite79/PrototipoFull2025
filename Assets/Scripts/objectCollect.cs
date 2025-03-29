using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectCollect : MonoBehaviour
{
 public int scoreValue = 1; // Puntos que otorga al recolectar.

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Añadir lógica de recolección (ej: aumentar puntuación).
            GameManager.Instance.AddScore(scoreValue);
            Destroy(gameObject); // Opcional: destruir el objeto al recolectar.
        }
    }
}
