using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour {

    public float pushForce;
    public float pushUpgrade;
    public GameObject pistonGo;
    public BoxCollider boxColl;
	// Use this for initialization
	void Start () {
        //timeDelay();
        boxColl = GetComponent<BoxCollider>();
        StartCoroutine(timetoWait());
        pushUpgrade = 4;
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemies" && boxColl.GetComponent<BoxCollider>().isTrigger == true)
        {
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
        pistonGo.SetActive(false);
        yield return new WaitForSeconds(pushUpgrade);
        pistonGo.SetActive(true);
        timeDelay();
    }
}
