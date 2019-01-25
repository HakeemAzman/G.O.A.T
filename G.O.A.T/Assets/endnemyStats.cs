using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class endnemyStats : MonoBehaviour
{

    public float enemyHealth = 3f;

    public float damageTaken;
    public GameObject winScreen;
    public Image healthbar;
    public GameObject healthbarHolder;
    CurrencySystem cs;

    SardineStats ss;

    private void Start()
    {

        damageTaken = 1f;
        cs = FindObjectOfType<CurrencySystem>();
        ss = FindObjectOfType<SardineStats>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            enemyHealth = enemyHealth - damageTaken;
            healthbar.fillAmount = enemyHealth / 3f;
            if (enemyHealth == 0f)
            {
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<NavMeshAgent>().enabled = false;
                healthbarHolder.SetActive(false);
                winScreen.gameObject.SetActive(true);
                Time.timeScale = 0;
                cs.AddBubbles(5);
            }
        }

        if (other.gameObject.tag == "PlayerTower")
        {
            Destroy(gameObject);
            ss.sardineHP -= ss.damageToTake;
        }
    }
}
