using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardArea
{
    [SerializeField] protected List<CardInfo> _cards = new List<CardInfo>();

    /// <summary> The number of cards left in the area </summary>
    public int numberOfCards => _cards.Count;

    /// <summary> Constructs a an empty card area </summary>
    public CardArea()
    {
    }

    /// <summary> Creates a deep copy of another card area (copying all cards) </summary>
    /// <param name="other">the card area to copy</param>
    public CardArea(CardArea other)
    {
        foreach (CardInfo otherCard in other._cards)
        {
            _cards.Add(otherCard);
        }
    }

    /// <summary> Adds a card on top of the area </summary>
    /// <param name="card">the card to be added to the area</param>
    public void AddCard(CardInfo card)
    {
        _cards.Add(card);
    }

    /// <summary> Moves all the cards from this area into another. </summary>
    /// <param name="otherArea"> The other area to add the cards to</param>
    public void MoveAllCardsTo(CardArea otherArea)
    {
        foreach (CardInfo card in _cards)
        {
            otherArea.AddCard(card);
        }
        _cards.Clear();
    }

    /// <summary> Shuffles the cards in the area </summary>
    public void Shuffle()
    {
        for (int firstCardIndex = 0; firstCardIndex < _cards.Count; firstCardIndex++)
        {
            int secondCardIndex = Random.Range(0, _cards.Count);
            if (firstCardIndex == secondCardIndex)
            {
                continue;
            }

            CardInfo firstCard = _cards[firstCardIndex];
            CardInfo secondCard = _cards[secondCardIndex];
            _cards[firstCardIndex] = secondCard;
            _cards[secondCardIndex] = firstCard;
        }
    }
}
