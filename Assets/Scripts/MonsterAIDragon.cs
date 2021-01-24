using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAIDragon : MonoBehaviour
{
    [Range(2, 100)]
    public float detectDistance = 20; // distance de detection
    public float detectDistanceFeu = 15; // distance de detection
    public float attackDistance = 10; // distance de detection
    Vector3 initialPos; // position d'origine
    public SphereCollider col; // Collider d'attauqye du monstre
    Transform hero; // Référence vers le perso principal
    bool canAttack = true; // Le monstre peux attaquer ?
    bool canAttackFeu = true; // Le monstre peux attaquer ?
    public NavMeshAgent agent;
    public MonsterMgr monsterMgr;
    private Animator anim;

    private void Start()
    {
        initialPos = transform.position;
        hero = GameObject.Find("RPGHeroHP").transform;
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (monsterMgr.life > 0)
        {
            float distance = Vector3.Distance(transform.position, hero.position);
            if ((distance < detectDistance) && distance > attackDistance) // si le joueur est visible mais pas a porté
            {
                // on s'approche
                anim.SetFloat("walkSpeed", agent.speed);
                agent.destination = hero.position;
            }
            if ((distance <= attackDistance) && canAttack) // si joueur a portée et can attack
            {
                // on peut attaquer
                agent.destination = hero.position;
                canAttack = false;
                int rand = Random.Range(0,2);
                print("rand " +rand);
                if (rand == 1)
                {
                    anim.SetTrigger("attack_basic");
                }
                else if(rand == 2)
                {
                    anim.SetTrigger("attack_claw");
                }
                StartCoroutine("AttackPlayer");
            }
            if ((distance <= detectDistanceFeu)&& (distance > attackDistance) && canAttackFeu) // si joeuur trop loin
            {
                anim.SetTrigger("attack_flame");
                StartCoroutine("AttackFeu");
            }
            if (distance > detectDistance) // si joeuur trop loin
            {
                // onretorune a la pos initiale
                agent.destination = initialPos;
            }
        }
    }

    IEnumerator AttackPlayer()
    {
        col.enabled = true;
        yield return new WaitForSeconds(1);
        col.enabled = false;
        yield return new WaitForSeconds(1);
        canAttack = true;
    }

    IEnumerator AttackFeu()
    {
        col.enabled = true;
        yield return new WaitForSeconds(3);
        col.enabled = false;
        yield return new WaitForSeconds(3);
        canAttackFeu = true;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectDistance);
    }
}
