namespace Bloodeck
{
    public interface IEntityAttackComponentHumbleObject : IEntityAttackComponentData
    {
        void SetAttacksLeftInTurn(int value);
        void SetAttacksPerTurn(int value);
    }
}