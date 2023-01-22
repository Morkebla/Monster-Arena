using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] float attackRange;
    [SerializeField] int damage;
    [SerializeField] float attackTime = 2.0f;

    private float attackTimer = 0.0f;

    GameObject target;

    MonsterHP enemyHP;
    NavMeshAgent agent;

    

    private Vector3 targetCoordinates => (target) ? target.transform.position : Vector3.zero;

    float distance => (transform.position - targetCoordinates).magnitude;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();        
    }

    void Update()
    {

        if (distance <= attackRange)
        {
            attackTimer -= Time.deltaTime;
            if (attackTimer <= 0.0f)
            {
                attackTimer = attackTime;
                Attack();
            }
        }

        if (target == null)
        {
            target = FindClosestTarget();
            enemyHP = target?.GetComponent<MonsterHP>();
        }
        else
        {
            agent.SetDestination(targetCoordinates);
        }
    }
    private void Attack()
    {
        // todo animator in the future
        if (enemyHP != null)
        {
            enemyHP.TakeDamage(damage);
        }
    }

    GameObject FindClosestTarget()
    {
        MonsterAI[] enemies = FindObjectsOfType<MonsterAI>();

        GameObject closestTarget = null;

        float maxDistance = Mathf.Infinity;

        foreach (MonsterAI enemy in enemies)
        {
            if (gameObject.tag != enemy.tag)
            {
                float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
                if (targetDistance < maxDistance)
                {
                    closestTarget = enemy.gameObject;
                    maxDistance = targetDistance;
                }
            }
        }
        return closestTarget;
    }

}

