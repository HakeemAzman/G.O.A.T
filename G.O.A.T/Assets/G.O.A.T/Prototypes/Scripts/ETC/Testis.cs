using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testis : MonoBehaviour {

    Projectiles p;

    Shooting s;

    [Header("Cannon")]
    public GameObject cannon;

    [Header("Ammo Type")]
    public GameObject waterTroops;
    public GameObject waterTower;

    [Header("Ammo Type Colors")]
    public Material red; //Water Tower
    public Material orange; //Water Troops

	// Use this for initialization
	void Start ()
    {
        p = FindObjectOfType<Projectiles>();
        s = FindObjectOfType<Shooting>();

        cannon.GetComponent<Renderer>().material.color = Color.yellow;
    }

    public void WaterTroops()
    {
        s.WaterBombs = waterTroops;
        cannon.GetComponent<Renderer>().material.color = Color.yellow;
    }

    public void WaterTowers()
    {
        s.WaterBombs = waterTower;
        cannon.GetComponent<Renderer>().material.color = Color.red;
    }
}
