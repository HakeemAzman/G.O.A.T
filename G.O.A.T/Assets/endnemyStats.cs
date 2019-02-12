using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class endnemyStats : MonoBehaviour
{
    AudioSource audio;

    public float enemyHealth = 3f;

    public float enemyFullhealth;

    public float damageTaken;

    public GameObject bubbleCurrencyParticle;

    public GameObject hat;

    public GameObject winScreen;

    public Image healthbar;

    CurrencySystem cs;

    SardineStats ss;

    public bool isdead = false;

    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        damageTaken = 1f;
        cs = FindObjectOfType<CurrencySystem>();
        ss = FindObjectOfType<SardineStats>();
    }

    private void Update()
    {
        if (enemyHealth <= 0f)
        {
            isdead = true;
            gameObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
            hat.SetActive(false);
            winScreen.gameObject.SetActive(true);
            //Time.timeScale = 0;
            //Destroy(gameObject, 1f);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            enemyHealth = enemyHealth - damageTaken;
            healthbar.fillAmount = enemyHealth / enemyFullhealth;

            if (enemyHealth <= 0f)
            {
                isdead = true;
                audio.Play();
                GameObject bubbleParticle = Instantiate(bubbleCurrencyParticle, transform.position, Quaternion.identity);
                bubbleParticle.transform.SetParent(gameObject.transform, true);
                Destroy(bubbleParticle, 1f);
            }
        }

        if (other.gameObject.tag == "PlayerTower")
        {
            //Destroy(gameObject);
            ss.sardineHP -= ss.endEnemyDamage;
        }

        if (other.gameObject.tag == "Piston")
        {
            StartCoroutine(PistonDeath());
        }
    }

    IEnumerator PistonDeath()
    {
        yield return new WaitForSeconds(2f);
        enemyHealth = 0f;
    }
}
