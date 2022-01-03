using System;
using Cysharp.Threading.Tasks;
using UnityEditor;
using Object = UnityEngine.Object;

namespace Editor
{
    public class AssetCreationNotifier : AssetModificationProcessor
    {
        public static event Action<string> WillCreateAsset;

        public static event Action<string, Object> AssetCreated;
            
        private static void OnWillCreateAsset(string assetPath)
        {
            WillCreateAsset?.Invoke(assetPath);
            WaitForAssetCreation(assetPath).Forget();
        }

        private static async UniTaskVoid WaitForAssetCreation(string assetPath)
        {
            Object createdAsset = default;
            await UniTask.WaitUntil(() =>
            {
                createdAsset = AssetDatabase.LoadAssetAtPath<Object>(assetPath);
                return createdAsset;
            });

            AssetCreated?.Invoke(assetPath, createdAsset);
        }
    }
}