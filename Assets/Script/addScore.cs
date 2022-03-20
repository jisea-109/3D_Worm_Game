using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class addScore : MonoBehaviour
{
    public Text score;
    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + Body_generator.score.ToString();
    }
}
