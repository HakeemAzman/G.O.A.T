using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selecting : MonoBehaviour
{
    public GameObject currentlySelected;

    public Vector3 placementPos;

    public Vector3 turretPos;

    public FakeCameraMovement fcm;

    Deployment dScript;

    private void Start()
    {
        dScript = FindObjectOfType<Deployment>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitGrid = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitGrid, Mathf.Infinity);

            if (hit)
            {
                //Debug.Log(hitGrid.collider.name);
               // Debug.Log(turretPos);

                //Finding object with "Snowball" and deploying Turret
                if(hitGrid.collider.tag == "Snowball")
                {
                    if(currentlySelected != hitGrid.collider.gameObject)
                    {
                        turretPos = hitGrid.collider.transform.position;

                        GameObject selectedTurrets = hitGrid.collider.transform.Find("Turret").gameObject;
                        selectedTurrets.SetActive(true);
                        selectedTurrets.GetComponentInChildren<Button>().onClick.AddListener(dScript.SnowballUpgrade);

                        fcm.enabled = false;     
                    }
                }

                //Finding object with "deploy" as child
                if (hitGrid.collider.transform.Find("Deploy"))
                {
                    placementPos = hitGrid.collider.transform.position;

                    fcm.enabled = false;

                    //Selecting another object?
                    if (currentlySelected != hitGrid.collider.gameObject)
                    {
                        //Setting World Canvas to true
                        GameObject selectedObject = hitGrid.collider.transform.Find("Deploy").gameObject;
                        selectedObject.SetActive(true);

                        //Deactivate the currently selected object
                        if (currentlySelected != null)
                        {
                            currentlySelected.transform.Find("Deploy").gameObject.SetActive(false);
                        }

                        currentlySelected = hitGrid.collider.gameObject; //Done by Keefe and Marcus

                    }
                }

                if (hitGrid.collider.tag == "Deselect")
                {
                    fcm.enabled = true;

                    if (currentlySelected != null)
                    {
                        currentlySelected.transform.Find("Deploy").gameObject.SetActive(false);
                        currentlySelected = null;
                    }
                }
            }
        }
    }
}
