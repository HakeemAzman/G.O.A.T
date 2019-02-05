using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Poison : MonoBehaviour
{
    public float poisonTimer = 5f;
    bool hasTouched;

    private NavMeshAgent agent;

    public GameObject poisonEffect;

	// Use this for initialization
	void Start ()
    {
        agent = GetComponent<NavMeshAgent>();
        hasTouched = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(hasTouched == true)
        {
            agent.speed = 0.5f;
        }
    }

    private void OnTriggerEnter(Collider enter)
    {
        if(enter.gameObject.tag == "Poison")
        {
            GameObject child = Instantiate(poisonEffect, transform.position, Quaternion.identity);
            child.transform.SetParent(gameObject.transform, true);
            hasTouched = true;
        }
    }
}
