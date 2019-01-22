using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piston : MonoBehaviour {

    public float pushForce;
    public GameObject pistonGo;
    
	// Use this for initialization
	void Start () {
        //timeDelay();
        StartCoroutine(timetoWait());
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemies")
        {
            other.GetComponent<Rigidbody>().AddForce(transform.right * pushForce, ForceMode.Acceleration);
        }
    }
    
    void timeDelay()
    {
        pistonGo.SetActive(true);
        StartCoroutine(timetoWait());
    }

   IEnumerator timetoWait()
    {
        yield return new WaitForSeconds(1);
        pistonGo.SetActive(false);
        yield return new WaitForSeconds(4);
        pistonGo.SetActive(true);
        timeDelay();
    }
}
