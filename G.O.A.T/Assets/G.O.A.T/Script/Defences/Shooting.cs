using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Vector3 mPosition;
    public Transform towerCrossbow;
    public Vector3 towerPosition;
    public float angle;

    public GameObject WaterBombs;

    // Update is called once per frame
    void Update ()
    {
        //Look at Mouse 
        mPosition = Input.mousePosition;
        towerPosition = Camera.main.WorldToScreenPoint(towerCrossbow.position);
        mPosition = new Vector3(mPosition.x - towerPosition.x, mPosition.y - towerPosition.y);
        angle = Mathf.Atan2(mPosition.x, mPosition.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, angle, 0);
        //END

        //Instantiate
        if (Input.GetButtonUp("Fire2"))
        {
           GameObject waterBombs =  (GameObject)Instantiate(WaterBombs, transform.position, Quaternion.Euler(0, angle - 90, 0));

           Destroy(waterBombs, 5f);
        }

    }
}
