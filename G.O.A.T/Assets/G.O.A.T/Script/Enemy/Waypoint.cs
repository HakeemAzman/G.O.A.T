using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [Header ("Waypoint Settings")]
    public GameObject[] waypoints;

    [Header("Enemy Movement Settings")]
    public float movementSpeed;
    float turningToWaypointSpeed = 7f;
    float pausingAtWaypoint = 0.5f;

    float realTime;
    int currentWaypoint = 0;
    CharacterController cc;

    Quaternion rotateTowards;

    Vector3 target;

	// Use this for initialization
	void Start ()
    {
        currentWaypoint = 0;
        cc = gameObject.GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(target);
        if (currentWaypoint < waypoints.Length)
        {
            Move();

            if (currentWaypoint >= waypoints.Length)
                Debug.Log("Dead");
        }
	}

    void Move()
    {
        target = waypoints[currentWaypoint].transform.position;
        target.y = transform.position.y;

        Vector3 moveDirection = target - transform.position; // Calculate the distance of next waypoint to enemy

        if (moveDirection.magnitude < 0.01)
        {
            if (realTime == 0)
                realTime = Time.time; // Pause over the waypoint
            if ((Time.time - realTime) >= pausingAtWaypoint) //Moves to the waypoint after pause time is complete
            {
                currentWaypoint++;
                realTime = 0;
            }
        }
        else
        {
            rotateTowards = Quaternion.LookRotation(target - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotateTowards, Time.deltaTime * turningToWaypointSpeed);
            cc.Move(moveDirection.normalized * movementSpeed * Time.deltaTime);
        }
    }
}
