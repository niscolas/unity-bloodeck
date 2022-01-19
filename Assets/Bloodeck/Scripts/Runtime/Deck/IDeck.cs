namespace Bloodeck
{
    public interface IDeck : IDeckData
    {
        ICard DrawFromTop();

        void LoadTemplate(IDeckTemplate template);
    }
}