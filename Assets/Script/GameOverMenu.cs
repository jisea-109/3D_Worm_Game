using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour
{
    public static bool flag = false;

    public GameObject endMenu;

    void Start()
    {
        endMenu.SetActive(false);
    }
    void Update()
    {
        if (flag == true)
        {
            Time.timeScale = 0f;
            endMenu.SetActive(true);
        }
    }
    public void Play()
    {
        Raycast.start = 0;
        Raycast.bodyMembers.Clear();
        Time.timeScale = 1f;
        endMenu.SetActive(false);
        flag = false;
        SceneManager.LoadScene("Scenes/SampleScene");
    }
    public void Quit()
    {
        endMenu.SetActive(false);
        flag = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Scenes/Scene2");
    }
}
