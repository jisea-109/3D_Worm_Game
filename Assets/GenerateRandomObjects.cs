using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomObjects : MonoBehaviour
{
    public GameObject obj;
    public int objectCount = 0;
    [SerializeField] private float CoordinateY;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(ObjectDrop());
        obj.name = "Parasite";
    }

    IEnumerator ObjectDrop()
    {
        while (objectCount < 1000)
        {
            int xPos = Random.Range(114,845);
            int zPos = Random.Range(-1345,-356);
            Instantiate(obj, new Vector3(xPos,CoordinateY, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.0001f);
            objectCount += 1;
        }
    }
}
