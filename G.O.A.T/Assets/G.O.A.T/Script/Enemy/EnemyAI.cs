using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    private NavMeshAgent agent;
    private Vector3 playerAI;

    public bool playerAiFound = true;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        playerAI = FindClosestPlayer().transform.position;
        agent.destination = playerAI;
        
    }

    GameObject FindClosestPlayer()
    {

        GameObject[] targets;

        targets = GameObject.FindGameObjectsWithTag("PlayerTower");
       
        
        GameObject closestPlayer = null;
        var distance = Mathf.Infinity;
        Vector3 position = transform.position;

        // Iterate through them and find the closest one
        foreach (GameObject target in targets)
        {
            Vector3 difference = (target.transform.position - position);
            float curDistance = difference.sqrMagnitude;
            if (curDistance < distance)
            {
                closestPlayer = target;
                distance = curDistance;
            }
        }

        return closestPlayer;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerTower")
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision enter)
    {
        if(enter.gameObject.tag == "Enemies")
        {
            Physics.IgnoreCollision(enter.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
}
