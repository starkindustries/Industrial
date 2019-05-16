using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameIsPaused = false;
    bool gameIsOver = false;

    public GameObject pauseMenuUI;
    public GameObject gameOverScreenUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    // Menu Actions
    public void Quit()
    {
        Debug.Log("Quit game!");
    }

    public void Restart()
    {
        Debug.Log("RESTART");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        gameIsOver = false;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    // Game Actions
    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void GameOver()
    {
        Invoke("GameOverHelper", 0.5f);
    }

    public void GameOverHelper()
    {
        Debug.Log("game over!");
        gameOverScreenUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsOver = true;
    }

    // Getters
    public bool IsPaused()
    {
        return gameIsPaused;
    }

    public bool IsGameOver()
    {
        return gameIsOver;
    }
}
