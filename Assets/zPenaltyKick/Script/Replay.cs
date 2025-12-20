using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
    public void RestartGame()
    {
        Time.timeScale = 1f;

        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
        
        Debug.Log("게임을 재시작합니다.");
    }
}