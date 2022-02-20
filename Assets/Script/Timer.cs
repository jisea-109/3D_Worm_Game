using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Text score;
    public float time = 0f;
    public int minutes;
    public int seconds;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        minutes = Mathf.FloorToInt(time / 60);
        seconds = Mathf.FloorToInt(time % 60);
        score.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
