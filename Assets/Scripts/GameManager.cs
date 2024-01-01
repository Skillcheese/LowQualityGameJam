using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    [Tooltip("This is for the reloading scene")]
    [SerializeField] int thisSceneIndex;

    private void Awake()
    {
        if(gameManager == null)
        {
            gameManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
        LockTheCursor();
    }

    public void LockTheCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void StartTheGame()
    {
        LockTheCursor();
        Time.timeScale = 1;
    }

    public void PauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(thisSceneIndex);
        StartTheGame();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
