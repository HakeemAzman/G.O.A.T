using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuTransition : MonoBehaviour {

    Animator m_Anim;

    bool m_Settings;
    bool m_Encyclopedia;

	// Use this for initialization
	void Start () {
        m_Anim = gameObject.GetComponent<Animator>();

        m_Settings = false;
        m_Encyclopedia = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (m_Settings == true)
            m_Anim.SetBool("SettingsBool", true);
        else
            m_Anim.SetBool("SettingsBool", false);

        if (m_Encyclopedia == true)
            m_Anim.SetBool("EncyclopediaBool", true);
        else
            m_Anim.SetBool("EncyclopediaBool", false);

        Debug.Log(m_Settings);


    }

    public void SettingsTransitition()
    {
        m_Settings = true;

    }

    public void EncyclopediaTransitition()
    {
        m_Encyclopedia = true;
    }

    public void BackTransition()
    {
        m_Settings = false;
        //m_Anim.SetBool("SettingsBool", false);

        m_Encyclopedia = false;
       // m_Anim.SetBool("EncyclopediaBool", false);

    }



}


