using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] GameObject monster;

    void Update()
    { 
        MonsterSummoner();
    }

    public void MonsterSummoner()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(monster != null)
            {
                Instantiate(monster);
            }
        }
        else
        {
            return;
        }
    }
}
