namespace Bloodeck
{
    public interface ICardSlotData
    {
        ICard Card { get; set; }
        
        ICardSlotRestrictions Restrictions { get; }
    }
}