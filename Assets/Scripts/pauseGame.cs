using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseGame : MonoBehaviour
{
    public static bool IsPaused = false;
    public GameObject PauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Escape))
        {
            if( !IsPaused && !player.GameOver ) Pause();
            else Resume();
        }
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        IsPaused = false;
        Time.timeScale = 1f;
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        IsPaused = true;
        Time.timeScale = 0f;
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }
}
