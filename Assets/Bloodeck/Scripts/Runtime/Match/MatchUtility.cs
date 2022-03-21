namespace Bloodeck
{
    public static class MatchUtility
    {
        
        public static bool CheckAreOppositeTeams(ITeam team, ITeam otherTeam)
        {
            bool result = team != otherTeam;
            return result;
        }
    }
}