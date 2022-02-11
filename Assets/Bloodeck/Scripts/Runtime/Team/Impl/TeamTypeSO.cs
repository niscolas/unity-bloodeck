using UnityEngine;

namespace Bloodeck
{
    [CreateAssetMenu(
        fileName = "TeamType",
        menuName = Constants.CreateAssetMenuPrefix + "Team Type",
        order = Constants.CreateAssetMenuOrder)]
    public class TeamTypeSO : ScriptableObject, ITeam { }
}