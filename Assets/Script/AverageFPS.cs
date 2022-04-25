using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AverageFPS : MonoBehaviour
{
    float average= 0F;
    private List<float> OverallFPS = new List<float>();
    // Update is called once per frame
    void Update()
    {
        average += ((Time.deltaTime/Time.timeScale) - average) * 0.03f;
        float fps = (1F/average);
        OverallFPS.Add(fps);

        float result = 0F;
        for (int i = 0; i < OverallFPS.Count; i++)
        {
            result +=OverallFPS[i];
        }
        result = result / OverallFPS.Count;
        Debug.Log(result);
    }
}
