namespace Lingua
{
    public interface IText { }
    
    public interface IText<in T> where T : ITextContext
    {
        string Get(T context);
    }
}