using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/// <summary> A script that controls the behavour of Had Card UI elements </summary>
public class HandCardUI : MonoBehaviour
{
    [SerializeField] Controller controller;
    [SerializeField] int CardHandIndex;

    [SerializeField] Image cardImage;
    [SerializeField] TextMeshProUGUI cardText;

    void Update()
    {
        CardInfo card = controller.GetHandCard(CardHandIndex);

        bool isVisible = (card != null);
        cardImage.enabled = isVisible;
        cardText.enabled = isVisible;

        if (card != null)
        {
            cardText.text = card.displayName;
        }
    }

    public void PlayCard()
    {
        controller.PlayCard(CardHandIndex);
    }
}
