namespace Bloodeck
{
    public interface IEntityComponentWithTemplate
    {
        void LoadCurrentTemplate();
    }

    public interface IEntityComponentWithTemplate<T> : IEntityComponentWithTemplate
        where T : IEntityComponentTemplate
    {
        void LoadTemplate(T template);
    }
}