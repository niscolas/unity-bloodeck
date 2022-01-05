using Zenject;

namespace Bloodeck
{
    public class CardAttackInstaller : Installer<CardAttackInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<CardAttackController>()
                .FromMethod(context => new CardAttackController(context.ObjectInstance as ICardAttack))
                .AsSingle()
                .WhenInjectedInto(typeof(ICard));
        }
    }
}