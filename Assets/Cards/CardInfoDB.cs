using System.Collections.Generic;
using UnityEngine;

/// <summary> Collection of cards </summary>
[CreateAssetMenu(fileName = "CardInfo", menuName = "Cards/Card Info Database", order = 1)]
public class CardInfoDB : ScriptableObject
{
    [SerializeField] List<CardInfo> _cardList;
    private Dictionary<string, CardInfo> _cardIndex;

    /// <summary>
    ///     Find and returns a card from the card list by ID
    ///     
    ///     Throws KeyNotFoundException if the cardID is not found.
    /// </summary>
    /// <param name="cardID">The ID of the card being searched.</param>
    /// <returns>The card info associated with the given card ID.</returns>
    public CardInfo FindCardByID(string cardID)
    {
        BuildCardIndexIfNeeded();
        
        Debug.Assert(_cardIndex.ContainsKey(cardID), $"The Card info DB does not contain '{cardID}'. Did you mispell it?");

        return _cardIndex[cardID];
    }

    /// <summary>
    ///     Builds an internal index to reference cards by ID (if the index doesn't yet exist)
    /// </summary>
    private void BuildCardIndexIfNeeded()
    {
        if (_cardIndex == null)
        {
            Debug.Assert(_cardList != null, "Something unspeakable has occured. _cardList is null");

            _cardIndex = new Dictionary<string, CardInfo>();
            foreach (var card in _cardList)
            {
                _cardIndex.Add(card.cardID, card);
            }
        }

        Debug.Assert(_cardIndex != null, "Something unspeakable has occured. _cardIndex is null");
    }

}
