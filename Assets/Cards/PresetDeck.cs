using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PresetDeck", menuName = "Cards/Preset Deck", order = 1)]
public class PresetDeck : ScriptableObject
{
    [SerializeField] Deck _deck;

    public Deck CreateDeck()
    {
        return new Deck(_deck);
    }
}
