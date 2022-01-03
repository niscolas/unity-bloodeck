using UnityEditor;
using UnityEngine;

namespace Editor
{
    public static class CreatedAssetsInjector
    {
        [InitializeOnLoadMethod]
        private static void Init()
        {
            AssetCreationNotifier.AssetCreated -= InjectIntoNewlyCreatedAsset;
            AssetCreationNotifier.AssetCreated += InjectIntoNewlyCreatedAsset;
        }

        private static void InjectIntoNewlyCreatedAsset(
            string assetPath, Object asset)
        {
            EditorContext.Container.Inject(asset);
        }
    }
}