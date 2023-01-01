using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHP : MonoBehaviour
{
    [SerializeField] int _maxHP = 100;
    int _currentHP;

    public int maxHP => _maxHP;
    public int currentHP => _currentHP;

    private void Awake()
    {
        _currentHP = _maxHP;
    }
    public void TakeDamage(int DamageAmount)
    {
        _currentHP -= DamageAmount;
        if(_currentHP <= 0)
        {
            Destroy(gameObject);
        }
    }
}
