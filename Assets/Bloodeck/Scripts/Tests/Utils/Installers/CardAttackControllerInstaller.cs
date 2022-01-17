using Zenject;

namespace Bloodeck.Tests.Editor
{
    public class CardAttackControllerInstaller : Installer<CardAttackControllerInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ICardAttackData>()
                .FromSubstitute()
                .AsTransient()
                .WhenInjectedInto(typeof(CardAttackController));

            Container
                .Bind<ICardAttack>()
                .To<CardAttackController>()
                .AsTransient();
        }
    }
}