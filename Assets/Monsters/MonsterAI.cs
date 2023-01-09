using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterAI : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] float attackRange;
    [SerializeField] int damage;
    [SerializeField] float attackTime = 2.0f;

    private float attackTimer = 0.0f;

    private Vector3 targetCoordinates => (target)? target.transform.position:Vector3.zero;
    float distance => (transform.position - targetCoordinates).magnitude;

    NavMeshAgent agent;
    MonsterHP enemyHp;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyHp = target.GetComponent<MonsterHP>();
    }

    private void Update()
    {
        if (target == null)
        {
            if(gameObject.tag == ("Team A"))
            {
                target = GameObject.FindGameObjectWithTag("Team B");
            }
            else if (gameObject.tag == ("Team B"))
            {
                target = GameObject.FindGameObjectWithTag("Team A");
            }
        }
        else
        {
            agent.SetDestination(targetCoordinates);
        }



        if (distance <= attackRange)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0.0f)
            {
                attackTimer = attackTime;
                Attack();
            }
        }
    }
    private void Attack()
    {
        // todo animator in the future
        enemyHp.TakeDamage(damage);
        Debug.Log("Damage: " + damage);
    }

}
