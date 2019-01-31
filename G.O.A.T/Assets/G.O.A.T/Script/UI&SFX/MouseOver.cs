using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOver : MonoBehaviour {

    Ray ray;
    RaycastHit hover;

    [Header("Information Text/Sound")]
    public Text infoText;
	
	// Update is called once per frame
	void Update ()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(ray, out hover))
        {
            if(hover.collider.tag == "Defence")
            {
                infoText.text = hover.collider.name;
            }
            else if (hover.collider.tag == "Snowball")
            {
                infoText.text = hover.collider.name;
            }
            else
            {
                infoText.text = "";
            }
        }
	}
}
