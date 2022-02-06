using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Raycast.start = 0;
        Raycast.bodyMembers.Clear();
        SceneManager.LoadScene("Scenes/SampleScene");
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
