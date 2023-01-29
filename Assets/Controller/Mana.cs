using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField] float _maxMana = 100f;
    [SerializeField] float _minMana = 0f;
    [SerializeField] float _currentMana;

    public float minMana { get { return _minMana; } }
    public float maxMana { get { return _maxMana; } }
    public float currentMana { get { return _currentMana; } }

    [SerializeField] float manaRegen = 1f;

    private void Start()
    {
        _currentMana = _maxMana;
    }

    private void Update()
    {
        ManaFlow();
    }

    private void ManaFlow()
    {
        _currentMana += manaRegen * Time.deltaTime;
        _currentMana = Mathf.Clamp(_currentMana, _minMana, _maxMana);
    }
    public bool ReduceMana(float cost)
    {
        if (cost <= _currentMana)
        {
            _currentMana -= cost;
            return true;
        }
        else
        {
            return false;
        }
    }
}
