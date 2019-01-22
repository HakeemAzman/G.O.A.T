using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootStats : MonoBehaviour {

    public float shootSpeed;
    public Rigidbody rb;
    TurretShooting tsScript;

	// Use this for initialization
	void Start () {
        shootSpeed = 20f;
        rb = GetComponent<Rigidbody>();
        tsScript = FindObjectOfType<TurretShooting>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        shootingSpeed();
    }

    public void shootingSpeed()
    {
        rb.velocity = transform.forward * shootSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemies")
        {
            Destroy(gameObject);
        }
    }

}
