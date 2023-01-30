using System.Collections.Generic;
using UnityEngine;

/// <summary> Collection of cards </summary>
[CreateAssetMenu(fileName = "CardInfo", menuName = "Cards/Card Info Database", order = 1)]
public class CardInfoDB : ScriptableObject
{
    [SerializeField] List<CardInfo> _cardList;
    private Dictionary<string, CardInfo> _cardIndex;

    /// <summary>
    ///     Find and returns a card from the card list by name 
    ///     
    ///     Throws KeyNotFoundException if the cardName is not found.
    /// </summary>
    /// <param name="cardName">The name of the card being searched.</param>
    /// <returns>The card info associated with the given card name.</returns>
    public CardInfo FindCardByName(string cardName)
    {
        BuildCardIndexIfNeeded();
        
        Debug.Assert(_cardIndex.ContainsKey(cardName), $"The Card info DB does not contain '{cardName}'. Did you mispell it?");

        return _cardIndex[cardName];
    }

    private void BuildCardIndexIfNeeded()
    {
        if (_cardIndex == null)
        {
            Debug.Assert(_cardList != null, "Something unspeakable has occured. _cardList is null");

            _cardIndex = new Dictionary<string, CardInfo>();
            foreach (var card in _cardList)
            {
                _cardIndex.Add(card.cardName, card);
            }
        }

        Debug.Assert(_cardIndex != null, "Something unspeakable has occured. _cardIndex is null");
    }

}
