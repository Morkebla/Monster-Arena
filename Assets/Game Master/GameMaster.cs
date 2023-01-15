using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] GameObject monster;
    [SerializeField] float cost = 20f;
    Mana mana;
    private void Start()
    {
        mana = gameObject.GetComponent<Mana>();
    }

    public void MonsterSummoner()
    {
        if (monster != null)
        {
            if (mana.ReduceMana(cost))
            {
                Instantiate(monster);
            }
        }
    }
}
