using TMPro;
// ...existing code...
// ��� ���������, ���� ��� ������ ��������� � Plane.OnTriggerEnter2D ��� Rocket.OnTriggerEnter2D
// ...existing code...
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int scoreCounter = 0;
    [SerializeField]
    private TextMeshProUGUI score;

    void Start()
    {
        score.text = "Score: " + scoreCounter; // ��������� ��������� � ������
    }

    public void UpdateScore()
    {
        scoreCounter++;
        score.text = "Score: " + scoreCounter; // ��������� ��������� � ������
    }
}