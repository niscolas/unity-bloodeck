namespace Bloodeck
{
    public interface ICardSlotData
    {
        ICard Card { get; }
        
        ICardSlotRestrictions CardRestrictions { get; }
    }
}