using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
[CreateAssetMenu(fileName = "MonsterCard", menuName = "Cards/Monster Card", order = 1)]
public class MonsterCardInfo : CardInfo
{
    [SerializeField] GameObject _monster;
    [SerializeField] float _manaCost;

    public float manaCost => _manaCost;
    public GameObject monster => _monster;

    public override bool CanBePlayed(Controller controller)
    {
        return _monster != null && controller.mana.currentMana >= manaCost;
    }

    public override bool Play(Controller controller)
    {
        if (_monster != null)
        {
            if (controller.mana.ReduceMana(manaCost))
            {
                controller.summoningComponent.SpawnMonster(_monster);
                return true;
            }
        }
        return false;
    }
}
