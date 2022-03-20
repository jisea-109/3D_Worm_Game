using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        Body_generator.start = 0;
        Body_generator.bodyMembers.Clear();
        SceneManager.LoadScene("Scenes/SampleScene");
        
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
