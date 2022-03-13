using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Animator_pause : MonoBehaviour
{
    private Animator animator;
    private int flag;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
         animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= 20)
        {
            flag = 1;
        }
        else
        {
            flag = 0;
        }
        var flag_controller = flag;
        animator.SetInteger("Flag", flag_controller);
        
    }
}
