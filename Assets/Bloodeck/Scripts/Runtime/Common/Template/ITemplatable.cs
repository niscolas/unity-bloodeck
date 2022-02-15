namespace Bloodeck
{
    public interface ITemplatable<T>
    {
        T TemplateToLoad { get; }
        T LoadedTemplate { get; }
        void LoadTemplate(T template);
    }
}