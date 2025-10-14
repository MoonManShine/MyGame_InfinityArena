using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuController : MonoBehaviour
{

    public FPCameraController cameraController;
    public GameObject gamePauseMenu;

    private bool isPaused = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
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
