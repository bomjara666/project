using UnityEngine;
// ...existing code...
// ��� ���������, ���� ��� ������ ��������� � Plane.OnTriggerEnter2D ��� Rocket.OnTriggerEnter2D
// ...existing code...
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private string cenename = "GameScene";
    public void onButtonclick()
    {       
        SceneManager.LoadScene(cenename);
    }
}
