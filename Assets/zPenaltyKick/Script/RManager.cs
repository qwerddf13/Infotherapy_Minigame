using UnityEngine;
using UnityEngine.SceneManagement;

public class RManager : MonoBehaviour
{
    [SerializeField] private GameObject panelA;

    void Update()
    {
        if ((panelA.activeSelf) &&
            Input.GetKeyDown(KeyCode.R))
        {
            RestartScene();
        }
    }

    void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}