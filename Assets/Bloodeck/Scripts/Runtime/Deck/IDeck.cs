namespace Bloodeck
{
    public interface IDeck : IDeckData
    {
        void LoadTemplate(IDeckTemplate template);
    }
}