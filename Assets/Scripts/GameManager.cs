using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
    public static GameManager Instance;
    private int score = 0;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Score: " + score); // Opcional: actualizar UI aquí.
    }

    public void PlayerDeath()
{
    // Reiniciar escena:
    score = 0;
    Debug.Log("Score: " + score);
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    
    // O restar una vida:
    // lives--;
    // if (lives <= 0) GameOver();
}

}
