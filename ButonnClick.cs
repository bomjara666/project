using UnityEngine;
// ...existing code...
// Ќет изменений, если нет пр€мых обращений к Plane.OnTriggerEnter2D или Rocket.OnTriggerEnter2D
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
