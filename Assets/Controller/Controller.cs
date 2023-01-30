using UnityEngine;

/// <summary>
/// A base controller class.
/// 
/// A controller represents a human or an AI player who has agency in the game and
/// is able to make decision and take actions.
/// 
/// The base controller contrains what most players would have this class further specializes into
/// AIController and PlayerController.
/// </summary>
public class Controller : MonoBehaviour
{
    [SerializeField] CardInfoDB _cardInfoDB;
    private SummoningComponent _summoningComponent;    
    private Mana _mana;

    public CardInfoDB cardInfoDB => _cardInfoDB;
    public Mana mana => _mana;
    public SummoningComponent summoningComponent => _summoningComponent;

    private void Awake()
    {
        _mana = GetComponent<Mana>();
        _summoningComponent = GetComponent<SummoningComponent>();
    }

    public void PlayCard(string cardName)
    {
        Debug.Assert(_cardInfoDB);
        CardInfo card = _cardInfoDB.FindCardByName(cardName);
        card?.Play(this);
    }
}
