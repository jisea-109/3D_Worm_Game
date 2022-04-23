using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static PlayerManagers;
using static Body_generator;
public class Controller : MonoBehaviour
{
    public float lookRadius;
    private List<GameObject> Body = new List<GameObject>();
    Transform target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManagers.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
       float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);

        }
        Body = Body_generator.bodyMembers;
        for (int i = 0; i < Body.Count; i++)
        {
            float distance2 = Vector3.Distance(Body[i].transform.position, transform.position);
            if (distance2 <= lookRadius)
            {
                agent.SetDestination(target.position);

            }
        }
    }
    // void Chase()
    // {
    //     Vector3 direction = (target.position - transform.position).normalized;
    //     Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
    //     transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    // }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
