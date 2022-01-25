using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallRenderer : MonoBehaviour
{
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<MeshRenderer>();
        rend.enabled = false;
    }

    void Invisible(Collision col)
    {
        if (col.gameObject.tag == "Ball" )
        {
            rend.enabled = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
 