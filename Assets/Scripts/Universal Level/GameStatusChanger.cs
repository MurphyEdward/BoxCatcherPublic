using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatusChanger : MonoBehaviour
{
    [SerializeField] private LevelInfo _levelInfo;

    public static bool IsGamePaused { get; private set; } = false;

    public static void PauseGame()
    {
        Time.timeScale = 0;
        IsGamePaused = true;
    }

    public static void RestartGame(LevelInfo levelInfo)
    {
        if(levelInfo.Settings)
        {
            levelInfo.Settings.IsChosenLevel = true;
        }
        ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void StartNextLevel()
    {
        ResumeGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public static void ResumeGame()
    {
        Time.timeScale = 1;
        IsGamePaused = false;
    }

    public static void BackToMainMenu()
    {
        ResumeGame();
        SceneManager.LoadScene(0);
    }
}
