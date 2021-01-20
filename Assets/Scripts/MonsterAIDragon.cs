using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAIDragon : MonoBehaviour
{
    [Range(2, 100)]
    public float detectDistance = 10; // distance de detection
    public float attackDistance = 2.4f; // distance de detection
    Vector3 initialPos; // position d'origine
    public SphereCollider col; // Collider d'attauqye du monstre
    Transform hero; // Référence vers le perso principal
    bool canAttack = true; // Le monstre peux attaquer ?
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
                anim.SetFloat("speed", agent.speed);

                anim.speed += 2;
                agent.destination = hero.position;

            }
            if ((distance <= attackDistance) && canAttack) // si joueur a portée et can attack
            {
                // on peut attaquer
                canAttack = false;
                anim.SetTrigger("attack");
                StartCoroutine("AttackPlayer");
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectDistance);
    }
}
