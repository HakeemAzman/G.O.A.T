using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class FoxEnemyAiStats : MonoBehaviour
{
    AudioSource audio;

    public float enemyHealth = 3f;

    public float enemyFullhealth;

    public float damageTaken;

    public GameObject bubbleCurrencyParticle;

    public GameObject hat;

    public Image healthbar;

    CurrencySystem cs;

    SardineStats ss;

    public GameObject skinmeshrenderer;

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
            skinmeshrenderer.GetComponent<SkinnedMeshRenderer>().enabled = false;
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<NavMeshAgent>().enabled = false;
            skinmeshrenderer.GetComponent<SkinnedMeshRenderer>().material.color = new Color(0, 0, 0, 0);
            hat.SetActive(false);
            Destroy(gameObject, 1f);
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
                audio.Play();
                cs.AddBubbles(30);
                GameObject bubbleParticle = Instantiate(bubbleCurrencyParticle, transform.position, Quaternion.identity);
                bubbleParticle.transform.SetParent(gameObject.transform, true);
                Destroy(bubbleParticle, 1f);
            }
        }

        if (other.gameObject.tag == "PlayerTower")
        {
            Destroy(gameObject);
            ss.sardineHP -= ss.damageToTake;
        }

        if (other.gameObject.tag == "Piston")
        {
            StartCoroutine(PistonDeath());
        }
    }

    IEnumerator PistonDeath()
    {
        audio.Play();
        cs.AddBubbles(30);
        GameObject bubbleParticle = Instantiate(bubbleCurrencyParticle, transform.position, Quaternion.identity);
        bubbleParticle.transform.SetParent(gameObject.transform, true);
        Destroy(bubbleParticle, 1f);

        yield return new WaitForSeconds(2f);

        enemyHealth = 0f;
    }
}
