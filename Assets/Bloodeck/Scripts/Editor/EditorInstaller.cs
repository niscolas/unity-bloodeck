using Lingua;
using Lingua.Extras;
using UnityEngine;
using Zenject;

namespace Bloodeck.Editor
{
    [CreateAssetMenu(menuName = "Installers/EditorInstaller")]
    public class EditorInstaller : ScriptableObjectInstaller<EditorInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<INoContextText>()
                .WithId(ZenjectIds.TextFieldId)
                .To<SimpleTextField>()
                .AsTransient();
            
            Container
                .Bind<INoContextText>()
                .WithId(default)
                .To<SimpleTextBox>()
                .AsTransient();

            Container
                .Bind<INoContextText>()
                .WithId(ZenjectIds.TextBoxId)
                .To<SimpleTextBox>()
                .AsTransient();
        }
    }
}