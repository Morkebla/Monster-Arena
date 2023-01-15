using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana : MonoBehaviour
{
    [SerializeField] float maxMana = 100f;
    [SerializeField] float minMana = 0f;
    [SerializeField] float currentMana;

    public float _currentMana { get { return currentMana; } }

    [SerializeField] float manaRegen = 1f;

    private void Start()
    {
        currentMana = maxMana;
    }

    private void Update()
    {
        ManaFlow();
    }

    private void ManaFlow()
    {
        currentMana += manaRegen * Time.deltaTime;
        currentMana = Mathf.Clamp(currentMana, minMana, maxMana);
    }
    public bool ReduceMana(float cost)
    {
        if (cost <= currentMana)
        {
            currentMana -= cost;
            return true;
        }
        else
        {
            return false;
        }
    }
}
