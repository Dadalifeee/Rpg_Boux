using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Caracteristique du perso
    public int xp = 0;
    public int force = 10;
    public int def = 6;
    public int crit = 5;
    public int life = 10;

    // Loot
    public GameObject[] lootSlime;


    //fonction

    public void ShowXP()
    {
        print("xp" + xp);
    }

}
