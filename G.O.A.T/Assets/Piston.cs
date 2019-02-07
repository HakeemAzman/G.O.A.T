using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Piston : MonoBehaviour
{
    [Header ("Blast Furnace Settings")]
    public float pushForce;
    public float pushUpgrade;
    public GameObject spawnHereBox;
    public GameObject pistonGo;
    public BoxCollider boxColl;
    public GameObject gustVFX;
    private float spawnHereTimer = 10f;

    // Use this for initialization
    void Start ()
    {
        gustVFX.SetActive(false);
        //timeDelay();
        boxColl = GetComponent<BoxCollider>();
        StartCoroutine(timetoWait());
	}

    private void Update()
    {
        spawnHereTimer -= Time.deltaTime;

        if (spawnHereTimer <= 0)
        {
            spawnHereBox.GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemies")
        {
            other.GetComponent<Rigidbody>().isKinematic = false;
            other.GetComponent<NavMeshAgent>().enabled = false;
            other.GetComponent<Rigidbody>().AddForce(transform.right * pushForce, ForceMode.Acceleration);
        }
    }

    void timeDelay()
    {
        pistonGo.SetActive(true);
        boxColl.GetComponent<BoxCollider>().enabled = true;
        StartCoroutine(timetoWait());
    }

    IEnumerator timetoWait()
    {
        yield return new WaitForSeconds(1);
        boxColl.gameObject.GetComponent<BoxCollider>().enabled = false;
        gustVFX.SetActive(false);
        pistonGo.SetActive(false);
        yield return new WaitForSeconds(pushUpgrade);
        gustVFX.SetActive(true);
        pistonGo.SetActive(true);
        timeDelay();
    }
}
