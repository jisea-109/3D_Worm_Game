using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public Text score;
    public float time = 0f;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        score.text = "Time: " + time.ToString("0.00");
    }
}
