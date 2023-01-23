using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] float summonCooldown = 0.4f;
    private float summonTimer = 0f;

    SummoningComponent summoningComponent;
    Mana mana;

    private void Awake()
    {
        mana = GetComponent<Mana>();
        summoningComponent = GetComponent<SummoningComponent>();
    }
    void Update()
    {
        summonTimer -= Time.deltaTime;
        if (mana.currentMana < Mathf.Infinity)
        {
            if (summonTimer <= 0)
            {
                summonTimer = summonCooldown;
                summoningComponent.MonsterSummoner();
            }
        }
    }
}
