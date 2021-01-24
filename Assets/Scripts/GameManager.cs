using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        LoadData();
    }
    //pour debug
    public Text dbg;

    // Caracteristique du perso
    public int lvl = 1;
    public int xp = 0;
    public float force = 10;
    public float def = 6;
    public float crit = 5;
    public int or = 10;
    public int life = 10;
    private double x = 1.2;
    // Loot
    public GameObject[] lootSlime;
    public GameObject oeil;

    //fonction

    public void UpLvl()
    {
        if(xp >= 500 * (lvl * 1.3))
        {
            xp -= (int)(500 * (lvl * 1.3));
            lvl += 1;
        }
    }

    public void SaveData()
    {
        UpLvl();
        PlayerPrefs.SetInt("xp", xp);
        PlayerPrefs.SetInt("or", or);
        PlayerPrefs.SetInt("lvl", lvl);
        PlayerPrefs.SetFloat("force", (float)(force + (lvl * x)));
        PlayerPrefs.SetFloat("crit", (float)(crit + (lvl * x)));
        PlayerPrefs.SetFloat("def", (float)(def + (lvl * x)));
        dbg.text = "Lvl = "+ lvl + "\n OR = " + or + "\n XP = " + xp;
    }

    public void LoadData()
    {
        xp = PlayerPrefs.GetInt("xp");
        or = PlayerPrefs.GetInt("or");
        lvl = PlayerPrefs.GetInt("lvl");
        force = PlayerPrefs.GetFloat("force");
        crit = PlayerPrefs.GetFloat("crit");
        def = PlayerPrefs.GetFloat("def");
        dbg.text = "Lvl = " + lvl + "\n OR = " + or + "\n XP = " + xp;
    }

}
