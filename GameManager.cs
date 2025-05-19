using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public void onGameStart()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void onRestartGame()
    {
        SceneManager.LoadScene("StartScene");
    }
}

