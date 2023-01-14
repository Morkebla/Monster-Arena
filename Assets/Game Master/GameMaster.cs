using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] GameObject monster;

    public void MonsterSummoner()
    {
        if(monster != null)
        {
            Instantiate(monster);
        }
    }
}
