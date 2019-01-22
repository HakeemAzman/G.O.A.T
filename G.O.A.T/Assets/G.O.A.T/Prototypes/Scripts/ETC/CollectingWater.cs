using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectingWater : MonoBehaviour
{
    [Header("UI Related")]
    public Text waterPercentage;
    public Slider waterSlider;

    [Header("Water Related")]
    public float percentageOfWater;
    public bool bucketFull = false;

    Water well;

    void Start()
    {
        percentageOfWater = 0f;

        well = FindObjectOfType<Water>();
    }

    void Update()
    {
        waterSlider.value = percentageOfWater;

        waterPercentage.text = percentageOfWater.ToString("F0") + "%";

        if (well.canCollectWater == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                percentageOfWater += 10 * Time.deltaTime;
                waterSlider.value = percentageOfWater;
            }
        }

        if (percentageOfWater >= 100)
        {
            bucketFull = true;
            percentageOfWater = 100f;
        }
    }

    public void WaterToLose(float howMuchToLose)
    {
        percentageOfWater -= howMuchToLose;
    }
}
