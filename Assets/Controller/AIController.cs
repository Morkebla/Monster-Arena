using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A controller specialized for AI players.
///
/// Defines the behaviour of the AI player.
/// </summary>
public class AIController : Controller
{
    [SerializeField] float summonCooldown = 0.4f;
    private float summonTimer = 0f;

    void Update()
    {
        summonTimer -= Time.deltaTime;
        if (mana.currentMana < Mathf.Infinity)
        {
            if (summonTimer <= 0)
            {
                summonTimer = summonCooldown;
                int cardToPlay = Random.Range(0, numberOfCardsInHand);
                PlayCard(cardToPlay);
            }
        }
    }
}
