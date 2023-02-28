public enum Team
{
    None,
    TeamA,
    TeamB,
}

public static class TeamUtils
{
    public static string ToTag(this Team team)
    {
        switch(team)
        {
            case Team.TeamA: return "TeamA";
            case Team.TeamB: return "TeamB";
            default: return "Untagged";
        }
    }
}