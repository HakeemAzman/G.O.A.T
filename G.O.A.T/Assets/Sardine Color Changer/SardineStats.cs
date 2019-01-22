using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SardineStats : MonoBehaviour {

    // ATTACH TO LEVEL MANAGER AND PLACE IN SARDINE PREFABS

    [SerializeField] public int sardineHP;
    public int damageToTake = 1;
    
    public Text sardineHealthText;

    SardineColor sc;

    // Prefabs Update
    public GameObject sardineFull;
    public GameObject sardineMedium;
    public GameObject sardineAlmostEmpty;
    public GameObject sardineEmpty;
    
    void Start()
    {
       // rend.material.color = originalColorGreen;      
        sc = FindObjectOfType<SardineColor>();

        //sardineHP = 20;
        sardineHealthText.text = ": " + sardineHP;                
    }

    void Update()
    {
       //  Debug.Log(sardineHP);

        sardineHealthText.text = ": " + sardineHP;

         if (sardineHP <= 0)        
         {
            sardineAlmostEmpty.SetActive(false);
            sardineEmpty.SetActive(true);
             Debug.Log("game over");
             SceneManager.LoadScene("GameOver Screen");           
         }

         else if (sardineHP <= 5)    // Red
         {
            sardineMedium.SetActive(false);
            sardineAlmostEmpty.SetActive(true);
            // rend.material.color = Color.Lerp(rend.material.color, sc.originalColorRed, Time.deltaTime);
            // renderer.material.color = originalColorRed;            
         }

         else if (sardineHP <= 10)    // Orange
         {
            sardineFull.SetActive(false);
            sardineMedium.SetActive(true);

             //rend.material.color = Color.Lerp(rend.material.color, sc.originalColorOrange, Time.deltaTime);
             //renderer.material.color = originalColorOrange;
         }

         else if (sardineHP <= 20)    // Green
         {
            // rend.material.color = sc.originalColorGreen;
             // Debug.Log("hello");
         }
    }
}
