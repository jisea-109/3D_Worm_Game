using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System.Linq;

public class Raycast : MonoBehaviour
{
    private Rigidbody rb;
    private int flag = 0;
    private static int num = 5;

    public static int start = 0;
    public static List<GameObject> bodyMembers = new List<GameObject>();
    public static int score = 0;
    [SerializeField] private GameObject objectToBeSpawned;
    [SerializeField] private Transform parent;
    [SerializeField] private GameObject parentObject;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (start == 0)
        {
            setup();
            start = 1;
        }
    }
    private void generate()
    {
        GameObject tail = bodyMembers.Last();
        int length = bodyMembers.Count + 1;
        float xPosition = parent.transform.position.x - tail.transform.position.x;
        float zPosition = parent.transform.position.z - tail.transform.position.z;
        float x_count = xPosition / length;
        float z_count = zPosition / length;
        x_count = x_count * -1;
        z_count = z_count * -1;
        Vector3 position;
        position = new Vector3(tail.transform.position.x + x_count, tail.transform.position.y, tail.transform.position.z + z_count);
        objectToBeSpawned = Instantiate(objectToBeSpawned, position, Quaternion.identity, parent);
        objectToBeSpawned.name = "Body_" + (num);
        bodyMembers.Add(objectToBeSpawned);
    }
    public void setup()
    {
        for (int i = 1; i <= 4; i++)
        {
            Vector3 position = new Vector3(parentObject.transform.position.x, 0.2f, parentObject.transform.position.z - (i * 0.65f));
            objectToBeSpawned = Instantiate(objectToBeSpawned, position, Quaternion.identity, parent);
            objectToBeSpawned.name = "Body_" + (i);
            bodyMembers.Add(objectToBeSpawned);
        }
        score = 0;
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "HeadnBody" || col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            score += 1;
            flag = 1;
        }
        if (flag == 1)
        {
            generate();
            flag = 0;
            num++;
        }
    }

    void Update()
    {
        Vector3 moveDirection = new Vector3(0, 0.0f, 0);
        rb.AddForce(moveDirection * .1f);
    }
}
