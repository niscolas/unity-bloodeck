using Zenject;

namespace Bloodeck.Tests.Editor
{
    public class CardAttackInstaller : Installer<CardAttackInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ICardAttackData>()
                .To<CardAttackData>()
                .AsTransient();

            Container
                .Bind<ICardAttack>()
                .To<CardAttackController>()
                .AsTransient()
                .OnInstantiated(
                    (InjectContext context, ICardAttack cardAttack) => { cardAttack.Owner.Components.Add(cardAttack); })
                .NonLazy();
        }
    }
}