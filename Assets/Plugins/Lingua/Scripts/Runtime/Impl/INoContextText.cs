namespace Lingua
{
    public interface INoContextText : IText<EmptyTextContext>
    {
        string Get();
    }
}