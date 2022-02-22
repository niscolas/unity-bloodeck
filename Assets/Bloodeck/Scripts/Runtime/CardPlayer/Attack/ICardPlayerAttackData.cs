namespace Bloodeck
{
    public interface ICardPlayerAttackData
    {
        ICardPlayer SelfCardPlayer { get; }
        IMatch Match { get; }
    }
}