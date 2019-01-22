using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class CurrencySystem : MonoBehaviour
{
    /*
    public int bubblesCount = 100;
    public Text bubblesText;
    
   // public TextMeshProUGUI bubblesText;

	// Use this for initialization
	void Start () {        
        //bubblesCount = 0;
        //bubblesText.text = "Bubbles: " + bubblesCount;
        bubblesText.text = ": " + bubblesCount;

        SetBubbles(PlayerPrefs.GetInt("bubblesCount"));
	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log(bubblesCount);
        //bubblesText.text = "Bubbles: " + bubblesCount;
        bubblesText.text = ": " + bubblesCount;
        
        //if (bubblesCount <= 0)
    }

    public void AddBubbles(int bubblesToAdd)
    {
        bubblesCount += bubblesToAdd;
        //bubblesText.text = "Bubbles: " + bubblesCount;
        bubblesText.text = ": " + bubblesCount;

        //PlayerPrefs.SetInt ("bubblesCount" , bubblesCount);
    }

    public void SubtractBubbles(int bubblesToSubtract)
    {
            bubblesCount -= bubblesToSubtract;

        //bubblesText.text = "Bubbles: " + bubblesCount;
        bubblesText.text = ": " + bubblesCount;

        if (bubblesCount < 0)
            bubblesCount = 0;
    }

    public void SetBubbles (int number)
    {
        bubblesCount = number;
        //bubblesText.text = "Bubbles: " + bubblesCount;
        bubblesText.text = ": " + bubblesCount;
    }

    */

    public Text bubblesText;
    [SerializeField] public int bubblesCount;

    public void AddBubbles (int bubblesToAdd)
    {
        bubblesCount += bubblesToAdd;
    }

    public void SubtractBubbles(int bubblesToSubtract)
    {
        bubblesCount -= bubblesToSubtract;
    }

    void Update()
    {
        bubblesText.text = ": " + bubblesCount.ToString();
    }

}
