using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomObjects : MonoBehaviour
{
    public GameObject objectPrefab;
    private int count;
    public int objectCount;
    [SerializeField] private float CoordinateY;

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
            Instantiate(objectPrefab, new Vector3(xPos,CoordinateY, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.00000001f);
            count += 1;
        }
    }
}
