using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAIstats : MonoBehaviour
{
    AudioSource audio;

    public float enemyHealth = 3f;

    public float enemyFullhealth;

    public float damageTaken;

    public Image healthbar;

    CurrencySystem cs;

    SardineStats ss;

    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        damageTaken = 1f;
        cs = FindObjectOfType<CurrencySystem>();
        ss = FindObjectOfType<SardineStats>();
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bullet")
        {
            enemyHealth = enemyHealth - damageTaken;
            healthbar.fillAmount = enemyHealth / enemyFullhealth;
            if (enemyHealth == 0f)
            {
                audio.Play();
                Destroy(gameObject, 0.5f);
                cs.AddBubbles(5);
            }
        }
        
        if(other.gameObject.tag == "PlayerTower")
        {
            Destroy(gameObject);
            ss.sardineHP -= ss.damageToTake;
        }
    }

}
