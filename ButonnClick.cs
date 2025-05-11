using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonClick : MonoBehaviour
{
    [SerializeField] private string cenename = "GameScene";
    public void onButtonclick()
    {       
        SceneManager.LoadScene(cenename);
    }
}
