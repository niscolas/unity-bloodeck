namespace Bloodeck
{
    public interface IDeckFromTemplateFactory
    {
        IDeck Create(IDeckTemplate template);
    }
}