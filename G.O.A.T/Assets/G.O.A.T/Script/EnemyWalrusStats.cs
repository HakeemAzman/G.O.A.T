using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWalrusStats : MonoBehaviour
{
    AudioSource audio;

    public float enemyHealth;

    public float enemyFullhealth;

    public float damageTaken;

    public Image healthbar;

    SardineStats ss;

    CurrencySystem cs;

    private void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
        damageTaken = 1f;
        cs = FindObjectOfType<CurrencySystem>();
        ss = FindObjectOfType<SardineStats>();
    }

    private void Update()
    {
        if (enemyHealth == 0f)
        {
            audio.Play();
            Destroy(gameObject, 1f);
            cs.AddBubbles(10);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            enemyHealth -= damageTaken;
            healthbar.fillAmount = enemyHealth / enemyFullhealth;
        }

        if (other.gameObject.tag == "PlayerTower")
        {
            Destroy(gameObject);
            ss.sardineHP -= ss.damageToTake;
        }

        if(other.gameObject.tag == "Piston")
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
