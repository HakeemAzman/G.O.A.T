using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Poison : MonoBehaviour
{
    public float poisonTimer = 5f;
    bool hasTouched;

    private NavMeshAgent agent;

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
            hasTouched = true;
        }
    }
}
