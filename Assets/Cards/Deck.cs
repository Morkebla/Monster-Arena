using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Deck : CardArea
{
    /// <summary> Creates an empty deck. </summary>
    public Deck() : base()
    {
    }

    /// <summary> Creates a deep copy of another deck </summary>
    /// <param name="other">the deck to copy</param>
    public Deck(Deck other) : base(other)
    {
    }

    /// <summary> Draws the top card of this deck (removing it from the deck) </summary>
    /// <returns>The card that was drawn. </returns>
    public CardInfo Draw()
    {
        if (_cards.Count == 0)
        {
            return null;
        }

        int topCardIndex = _cards.Count - 1;
        CardInfo topCard = _cards[topCardIndex];
        _cards.RemoveAt(topCardIndex);
        return topCard;
    }    
}
