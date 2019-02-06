using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SardineStats : MonoBehaviour {

    // ATTACH TO LEVEL MANAGER AND PLACE IN SARDINE PREFABS

    [SerializeField] public int sardineHP;
    public int damageToTake = 1;
    public int endEnemyDamage = 5;
    
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
       
        sardineHealthText.text = ": " + sardineHP;                
    }

    void Update()
    {
        sardineHealthText.text = ": " + sardineHP;

         if (sardineHP <= 0)        
         {
            sardineEmpty.SetActive(true);
            sardineMedium.SetActive(false);
             SceneManager.LoadScene("GameOver Screen");           
         }

         else if (sardineHP <= 5)    // Red
         {
            sardineFull.SetActive(false);
            sardineMedium.SetActive(true);
        }

         else if (sardineHP <= 10)    // Orange
         {
            sardineFull.SetActive(true);
         }
    }
}
