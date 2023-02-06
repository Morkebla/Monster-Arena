using UnityEngine;

/// <summary>
/// An abstract card info scriptable object.
/// 
/// Describes a generic card which can be a monster, a spell, an equipment, etc...
/// This class defines the minimal functionality and attributes every card should have. 
/// </summary>
[System.Serializable]
public abstract class CardInfo : ScriptableObject
{
    [SerializeField] string _cardID;
    [SerializeField] string _displayName;

    public string cardID => _cardID;
    public string displayName => _displayName;


    /// <summary> Returns wether the card can be played the specified controller. </summary>
    /// <param name="controller">The Player or AI controller to test the card with</param>
    /// <returns>true if the card can be played by the controller; false otherwise</returns>
    public abstract bool CanBePlayed(Controller controller);

    /// <summary> Plays the card effect for the specified controller </summary>
    /// <param name="controller">The Player or AI controller to play the card for</param>
    /// <returns>returns true if the card was successfully played; false otherwise</returns>
    public abstract bool Play(Controller controller);
}