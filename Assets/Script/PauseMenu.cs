using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool flag = false;

    public GameObject pauseMenuUI;
    // Update is called once per frame
    void Start()
    {
        pauseMenuUI.SetActive(false);
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        flag = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        flag = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (flag)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void BacktoMainMenu()
    {
        Resume();
        SceneManager.LoadScene("Scenes/Scene2");
    }
}
