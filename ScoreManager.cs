using TMPro;
// ...existing code...
// Нет изменений, если нет прямых обращений к Plane.OnTriggerEnter2D или Rocket.OnTriggerEnter2D
// ...existing code...
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int scoreCounter = 0;
    [SerializeField]
    private TextMeshProUGUI score;

    void Start()
    {
        score.text = "Score: " + scoreCounter; // Добавлено двоеточие и пробел
    }

    public void UpdateScore()
    {
        scoreCounter++;
        score.text = "Score: " + scoreCounter; // Добавлено двоеточие и пробел
    }
}