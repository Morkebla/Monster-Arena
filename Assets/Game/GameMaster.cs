using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    List<Controller> _controllers;

    public void RegisterController(Controller controller)
    {
        _controllers.Add(controller);
    }

    public Team AssignTeam(Controller controller)
    {
        if (_controllers.Count >= 1 && _controllers[0] == controller)
        {
            return Team.TeamA;
        }
        else if (_controllers.Count >= 2 && _controllers[1] == controller)
        {
            return Team.TeamB;
        }

        Debug.LogError("Too many players!");
        return Team.None;
    }
}
