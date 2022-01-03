using UnityEditor;
using Zenject;

namespace Editor
{
    public static class EditorContext
    {
        private const string InstallerPath = "Installers/EditorInstaller";

        private static DiContainer _container;

        public static DiContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = GetContainer();
                }

                return _container;
            }
        }

        [InitializeOnLoadMethod]
        private static void Init()
        {
            if (_container != null)
            {
                return;
            }

            _container = GetContainer();
        }

        private static DiContainer GetContainer()
        {
            DiContainer container = new DiContainer();
            container
                .InstantiateScriptableObjectResource<ScriptableObjectInstaller>(InstallerPath)
                .InstallBindings();

            return container;
        }
    }
}