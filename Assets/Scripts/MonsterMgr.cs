using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMgr : MonoBehaviour
{
    public GameObject[] hitParticule;
    public GameObject diedParticule;
    public GameObject bloodParticule;
    public Animator anim;
    public int life = 3;
    bool isDead = false;
    bool canAttack = true;
    public bool isBoss = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Sword" && canAttack)
        {
            canAttack = false;
            GameObject go = Instantiate(hitParticule[Random.Range(0, 2)], transform.position, Quaternion.identity);
            Destroy(go, 2);
            GameObject goBlood = Instantiate(bloodParticule, other.gameObject.transform.position, Quaternion.identity);
            Destroy(goBlood, 2);
            anim.SetTrigger("hitted");
            life--;
            print("life du monstre = " + life);
            CheckIsDead();
            StartCoroutine("AttackPlayer");
        }
       if (other.gameObject.name == "SpellMisc" || other.gameObject.name == "SpellFire" || other.gameObject.name == "SpellIce")
        {
            life -= 10;
            print("magie -10");
            CheckIsDead();
        }
    }

    public void CheckIsDead()
    {
        if (life <= 0 && !isDead)
        {
            isDead = true;
            GameManager.Instance.xp += 100;
            anim.SetTrigger("died");
            Destroy(this.gameObject, 3);
            GameObject go2 = Instantiate(diedParticule, transform.position, Quaternion.identity);
            Destroy(go2, 2);
            if (!isBoss)
            {
                if (Random.Range(0, 100) > 50)
                {
                    GameObject loot = Instantiate(GameManager.Instance.lootSlime[Random.Range(0, 2)], transform.position, Quaternion.identity);
                    loot.transform.position += Vector3.up;
                    loot.name = "Fiole";
                }
            }
            else
            {
                GameObject loot = Instantiate(GameManager.Instance.oeil, transform.position, Quaternion.identity);
                loot.transform.position += Vector3.up;
                loot.name = "oeil";
            }
        }
    }
    IEnumerator AttackPlayer()
    {
        yield return new WaitForSeconds(0.500F);
        canAttack = true;
    }

}
