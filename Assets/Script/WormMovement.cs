using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Raycast;

public class WormMovement : MonoBehaviour
{
    private float MoveSpeed = 6;
    private float SteerSpeed = 180;
    private int gap = 30;

    private List<Vector3> PositionHistory = new List<Vector3>();
    private List<GameObject> BodyParts = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float steerDirection = Input.GetAxis("Horizontal");

        if (Input.GetMouseButtonDown(0))
        {
            MoveSpeed = 12;
            if (gap > 0)
            {
                gap -= 1;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            MoveSpeed = 6;
            if (gap < 28)
            {
                gap += 1;
            }
        }
        BodyParts = Raycast.bodyMembers;
        transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        PositionHistory.Insert(0, transform.position);

        transform.Rotate(Vector3.up * steerDirection * SteerSpeed * Time.deltaTime);

        int index = 0;
        foreach (var body in BodyParts)
        {
            Vector3 point = PositionHistory[Mathf.Min(index * gap, PositionHistory.Count - 1)];
            body.transform.position = point;
            index++;
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Wall")
        {
            Debug.Log("Detect wall");
            //Destroy(this.gameObject);
        }
    }
}
