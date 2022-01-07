using Zenject;

namespace Bloodeck.Tests.Editor
{
    public class CardAttackProxyInstaller : Installer<CardAttackProxyInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<ICardAttack>()
                .To<CardAttackProxy>()
                .AsTransient()
                .OnInstantiated(
                    (InjectContext context, ICardAttack cardAttack) =>
                    {
                        cardAttack.SelfCard.Components.Add(cardAttack);
                    })
                .NonLazy();
        }
    }
}