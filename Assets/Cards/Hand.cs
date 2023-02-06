using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : CardArea
{
    /// <summary> Returns the card at the specified index, or null of the index is out of bounds. </summary>
    /// <param name="cardIndex">the index of the card in the hand</param>
    /// <returns>the card at the specified index, or null of the index is out of bounds.</returns>
    public CardInfo GetCardAt(int cardIndex)
    {
        if (cardIndex >= 0 && cardIndex < _cards.Count)
        {
            return _cards[cardIndex];
        }

        return null;
    }

    /// <summary> Attempts to play a card from the hand at the specified index. </summary>
    /// <param name="controller">the controller instigating the play</param>
    /// <param name="cardIndex">the index of the card in the hand</param>
    /// <returns>Returns the card that was played or null if the playing of the card failed</returns>
    public CardInfo PlayCard(Controller controller, int cardIndex)
    {
        CardInfo cardInfo = GetCardAt(cardIndex);
        if (cardInfo != null)
        {
            bool playSucceeded = cardInfo.Play(controller);
            if (playSucceeded)
            {
                _cards.RemoveAt(cardIndex);
                return cardInfo;
            }
        }

        return null;
    }
}
