using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using System.Linq;

public class Body_generator : MonoBehaviour
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
         Vector3 position;
        position = new Vector3(0, tail.transform.position.y, 0);
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
        if (col.gameObject.tag == "HeadnBody")
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
