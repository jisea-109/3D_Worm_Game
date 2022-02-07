using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Text score;
    public float time = 0f;
    public int minutes;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        minutes = Mathf.RoundToInt(time / 60);
        score.text = "Time: " + minutes.ToString("00") + ": " + time.ToString("00");
    }
}
