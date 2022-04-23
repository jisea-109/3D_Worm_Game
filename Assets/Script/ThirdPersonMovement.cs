using System.Collections;


using System.Collections.Generic;
using UnityEngine;
using static Body_generator;
public class ThirdPersonMovement : MonoBehaviour
{
    bool flag = false; // to prevent the error from IndexError
    public CharacterController controller;

    private float speed = 6;
    private int gap = 12;
    private int steerspeed = 180;
    float vertical;
    float horizontal;

    Vector3 velocity;
    public float gravity = -9.81f;

    private List<Vector3> PositionHistory = new List<Vector3>();
    private List<GameObject> BodyParts = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.W))
        {
            vertical = Input.GetAxisRaw("Vertical");
        }
        if (!Input.GetKey(KeyCode.W))
        {
            vertical = 0f;
        }
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            speed = 10;
            if (gap > 1)
            {
                if (!Input.GetKey(KeyCode.W))
                {
                    ;
                }
                else
                {
                    gap -= 1;
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            speed = 6;
            if (gap < 12)
            {
                gap += 1;
            }
        }
        float dTime = Time.deltaTime;
        if (dTime > 0.3f)
        {
            dTime = 0.3f;
        }
        if (direction.magnitude >= 0.1f)
        {
            transform.Rotate(Vector3.up * horizontal * steerspeed * dTime);
            controller.Move(transform.forward * speed * dTime);
            PositionHistory.Insert(0, transform.position);
            flag = true;
        }
        BodyParts = Body_generator.bodyMembers;
        if (flag == true)
        {
            for (int i = 0; i < BodyParts.Count; i++)
            {
                Vector3 point = PositionHistory[Mathf.Min(i * gap, PositionHistory.Count - 1)];
                BodyParts[i].transform.position = point;
            }
        }
        if (PositionHistory.Count > 1000)
        {
            PositionHistory.RemoveRange(BodyParts.Count*gap,1000-BodyParts.Count*gap);
        }
    }
}