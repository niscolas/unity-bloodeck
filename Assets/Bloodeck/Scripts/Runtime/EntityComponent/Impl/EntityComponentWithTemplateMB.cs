namespace Bloodeck
{
    public abstract class EntityComponentWithTemplateMB : EntityComponentMB, IEntityComponentWithTemplate
    {
        public abstract void LoadCurrentTemplate();
    }
}