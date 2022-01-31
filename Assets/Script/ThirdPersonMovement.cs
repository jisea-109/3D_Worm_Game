using System.Collections;


using System.Collections.Generic;
using UnityEngine;
using static Raycast;
public class ThirdPersonMovement : MonoBehaviour
{
    bool flag = false;
    public CharacterController controller;
    public Transform cam;

    private float speed = 6;
    private int gap = 12;

    Vector3 velocity;
    public float gravity = -9.81f;

    private List<Vector3> PositionHistory = new List<Vector3>();
    private List<GameObject> BodyParts = new List<GameObject>();
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            speed = 12;
            if (gap > 1)
            {
                gap -= 1;
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
        if (direction.magnitude >= 0.1f)
        {
            transform.Rotate(Vector3.up * horizontal * 180 * Time.deltaTime);
            controller.Move(transform.forward * speed * Time.deltaTime);
            PositionHistory.Insert(0, transform.position);
            flag = true;
        }
        if (flag == true)
        {
            BodyParts = Raycast.bodyMembers;
            for (int i = 0; i < BodyParts.Count; i++)
            {
                Vector3 point = PositionHistory[Mathf.Min(i * gap, PositionHistory.Count - 1)];
                BodyParts[i].transform.position = point;
            }
        }
    }
}