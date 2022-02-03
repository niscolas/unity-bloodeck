using UnityEngine;

namespace Bloodeck
{
    public interface IGameObject
    {
        GameObject GameObject { get; }

        Transform Transform { get; }
    }
}