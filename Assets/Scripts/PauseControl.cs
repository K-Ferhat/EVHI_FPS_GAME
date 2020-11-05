using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseControl : MonoBehaviour
{
    public GameObject inGameScreen;
    public GameObject pauseMenu;
    public static bool gameIsPaused;

    void Start(){
        gameIsPaused = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            gameIsPaused = !gameIsPaused;
        }        

        if (gameIsPaused)
            Activate();
        else
            Deactivate();
    }

    public void Activate() {
        Time.timeScale = 0f;
        //inGameScreen.SetActive(false);
        pauseMenu.SetActive(true);
        gameIsPaused = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void Deactivate() {
        Time.timeScale = 1;
        //inGameScreen.SetActive(true);
        pauseMenu.SetActive(false);
        gameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Restart() {
        SceneManager.LoadScene(1);
    }

    public void Quit() {
        Debug.Log("Quitting the game!");
        Application.Quit();
    }
}
