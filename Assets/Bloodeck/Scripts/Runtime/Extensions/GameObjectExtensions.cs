using UnityEngine;
using UnityEngine.SceneManagement;

namespace Bloodeck
{
    public static class GameObjectExtensions
    {
        public static void MoveToActiveScene(this GameObject self)
        {
            SceneManager.MoveGameObjectToScene(
                self,
                SceneManager.GetActiveScene());
        }
    }
}