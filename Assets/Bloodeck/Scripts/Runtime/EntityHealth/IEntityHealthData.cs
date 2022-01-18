namespace Bloodeck
{
    public interface IEntityHealthData : IEntityComponent
    {
        bool CanHeal { get; set; }

        bool CanTakeDamage { get; set; }

        float Current { get; set; }

        float Max { get; set; }

        float Min { get; set; }
    }
}