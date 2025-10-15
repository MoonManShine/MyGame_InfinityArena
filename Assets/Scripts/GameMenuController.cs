using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour
{

    public FPCameraController cameraController;
    public GameObject gamePauseMenu;
    public GameObject gameOverMenu;

    private bool isPaused = false;
    private bool isGameOver = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGameOver) return;
            if (isPaused)
                ResumeGame();
            else
                GamePause();
        }
    }
    public void GamePause()
    {
        gamePauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        if (cameraController != null)
            cameraController.canLook = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void GameOver()
    {
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
        isGameOver = true;

        if (cameraController != null)
            cameraController.canLook = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        gamePauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        if (cameraController != null)
            cameraController.canLook = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
