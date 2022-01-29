using System.Collections;


using System.Collections.Generic;
using UnityEngine;
using static Raycast;
public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    private float speed = 6;
    private int gap = 12;
    private float jumpSpeed;
    private float ySpeed;
    private float originalStepOffset;

    private List<Vector3> PositionHistory = new List<Vector3>();
    private List<GameObject> BodyParts = new List<GameObject>();
    void Start()
    {
        originalStepOffset = controller.stepOffset;
    }
    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        ySpeed += Physics.gravity.y * Time.deltaTime;
        BodyParts = Raycast.bodyMembers;
        if (controller.isGrounded)
        {
            controller.stepOffset = originalStepOffset;
            ySpeed = -0.5f;

            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
            }
        }
        else
        {
            controller.stepOffset = 0;
        }
        Vector3 velocity = direction * direction.magnitude;
        velocity.y = ySpeed;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetMouseButtonDown(0))
        {
            speed = 12;
            if (gap > 0)
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
            //transform.rotation = Quaternion.Euler(0f, angle, 0f);
            controller.Move(transform.forward * speed * Time.deltaTime);
            PositionHistory.Insert(0, transform.position);
        }
        if (BodyParts.Count < 5)
        {
            for (int i = 0; i <= 4; i++)
            {
                Vector3 point = PositionHistory[Mathf.Min(i * gap, PositionHistory.Count - 1)];
                BodyParts[i].transform.position = point;
            }
            return;
        }
        for (int i = 0; i < BodyParts.Count; i++)
        {
            Vector3 point = PositionHistory[Mathf.Min(i * gap, PositionHistory.Count - 1)];
            BodyParts[i].transform.position = point;
        }
    }
}