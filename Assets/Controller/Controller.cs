using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Unity.Netcode;

/// <summary>
/// A base controller class.
/// 
/// A controller represents a human or an AI player who has agency in the game and
/// is able to make decision and take actions.
/// 
/// The base controller contrains what most players would have this class further specializes into
/// AIController and PlayerController.
/// </summary>
public class Controller : NetworkBehaviour
{
    [SerializeField] PresetDeck _presetDeck;
    [SerializeField] GameObject _heroMonsterPrefab;

    private Deck _deck;
    private Deck _discardPile;
    private Hand _hand;

    private GameMaster _gameMaster;

    private SummoningComponent _summoningComponent;    
    private Mana _mana;
    private Team _team;

    private const float _drawTime = 3.0f;
    private const int _startingHandSize = 3;


    public Mana mana => _mana;
    public SummoningComponent summoningComponent => _summoningComponent;

    public int numberOfCardsInHand => _hand.numberOfCards;

    private void Awake()
    {
        _mana = GetComponent<Mana>();
        _summoningComponent = GetComponent<SummoningComponent>();
        _gameMaster = FindObjectOfType<GameMaster>();

        _deck = _presetDeck.CreateDeck();
        _discardPile = new Deck();
        _hand = new Hand();

        _deck.Shuffle();
    }

    private void Start()
    {
        StartCoroutine(AutoDraw());

        // Draw the starting hand
        for (int i = 0; i < _startingHandSize; i++)
        {
            DrawCard();
        }
    }

    public override void OnNetworkSpawn()
    {
        _gameMaster.RegisterController(this);
        AssignTeam();        
    }

    private void AssignTeam()
    {
        _team = _gameMaster.AssignTeam(this);
        gameObject.tag = _team.ToTag();
    }

    IEnumerator AutoDraw()
    {
        while (true)
        {
            yield return new WaitForSeconds(_drawTime);
            if (_hand.numberOfCards < 5)
            {
                DrawCard();
                if (_deck.numberOfCards == 0)
                {
                    _discardPile.MoveAllCardsTo(_deck);
                    _deck.Shuffle();
                }
            }
        }
    }

    public void PlayCard(int handIndex)
    {
        Debug.Assert(_hand != null);
        Debug.Assert(_discardPile != null);

        CardInfo playedCard = _hand.PlayCard(this, handIndex);
        if (playedCard != null)
        {
            _discardPile.AddCard(playedCard);
        }
    }

    public CardInfo GetHandCard(int handIndex)
    {
        Debug.Assert(_hand != null);
        return _hand.GetCardAt(handIndex);
    }

    private void DrawCard()
    {
        Debug.Assert(_hand != null);
        Debug.Assert(_deck != null);

        CardInfo drawnCard = _deck.Draw();
        if (drawnCard != null)
        {
            _hand.AddCard(drawnCard);
        }
    }
}
