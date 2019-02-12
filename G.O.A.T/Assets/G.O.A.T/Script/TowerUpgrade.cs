using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerUpgrade : MonoBehaviour
{
    CurrencySystem cs;
    public Animator anim;
    public bool isUpgradable;
    public bool isUpgradable2;
    public bool isUpgradable3;
    public bool isUpgradable4;
    public bool isNewSpawner;
    public GameObject upgrade;
    public GameObject upgrade2;
    public GameObject upgrade3;
    public GameObject upgrade4;
    public GameObject newSpawner;
    public GameObject oldSpawner;
    public Text upgradeText;

    // Use this for initialization
    void Start()
    {
        cs = FindObjectOfType<CurrencySystem>();
        anim = GetComponent<Animator>();
        isUpgradable = false;
        isUpgradable2 = false;
        isUpgradable3 = false;
        isUpgradable4 = false;
        isNewSpawner = false;
        upgradeText.text = "100";
    }

    private void Update()
    {
        if (isUpgradable2)
            upgradeText.text = "250";
        if (isUpgradable3)
            upgradeText.text = "400";
        if (isUpgradable4)
            upgradeText.text = "550";

        if(isNewSpawner)
        {
            newSpawner.SetActive(true);
        }
    }

    public void Upgrade1()
    {
        if (cs.bubblesCount >= 100)
        {
            isUpgradable = true;

            if (isUpgradable == true)
            {
                cs.bubblesCount -= 100;
                anim.SetBool("canUpgrade", true);
                isUpgradable2 = true;
                upgrade2.gameObject.SetActive(true);
                upgrade.gameObject.SetActive(false);
            }
        }
    }

    public void Upgrade2()
    {
        if(cs.bubblesCount >= 250 && isUpgradable2)
        {
            anim.SetBool("canUpgrade", false);
            cs.bubblesCount -= 250;
            anim.SetBool("canUpgrade2", true);
            isUpgradable3 = true;
            upgrade2.gameObject.SetActive(false);
            upgrade3.gameObject.SetActive(true);
        }
    }

    public void Upgrade3()
    {
        if (cs.bubblesCount >= 400 && isUpgradable3)
        {
            anim.SetBool("canUpgrade2", false);
            cs.bubblesCount -= 400;
            anim.SetBool("canUpgrade3", true);
            isUpgradable4 = true;
            upgrade3.gameObject.SetActive(false);
            upgrade4.gameObject.SetActive(true);
        }
    }

    public void Upgrade4()
    {
        if (cs.bubblesCount >= 550 && isUpgradable4)
        {
            anim.SetBool("canUpgrade3", false);
            cs.bubblesCount -= 550;
            anim.SetBool("canUpgrade4", true);
            StartCoroutine(DisableUpgrade4());
            isNewSpawner = true;
            oldSpawner.SetActive(false);
        }
    }

    IEnumerator DisableUpgrade4()
    {
        yield return new WaitForSeconds(10f);
        upgrade4.gameObject.SetActive(false);
    }
    
}
