using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomObjects : MonoBehaviour
{
    public GameObject obj;
    public int count;
    public int objectCount;
    [SerializeField] private float CoordinateY;

    // Update is called once per frame
    void Start()
    {
        StartCoroutine(ObjectDrop());
    }

    IEnumerator ObjectDrop()
    {
        while (count < objectCount)
        {
            int xPos = Random.Range(130,834);
            int zPos = Random.Range(-1320,-362);
            Instantiate(obj, new Vector3(xPos,CoordinateY, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.00000001f);
            count += 1;
        }
    }
}
