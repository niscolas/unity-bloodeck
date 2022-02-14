namespace Bloodeck
{
    public static class EntityComponentExtensions
    {
        public static bool TryGetCurrentTemplate<T>(this IEntityComponent self, out T template)
            where T : IEntityComponentTemplate
        {
            return self.OwnerEntity.LoadedTemplate.ComponentTemplates.TryGet(out template);
        }

        public static void TryLoadCurrentTemplate<T, TComponent>(this TComponent self)
            where T : IEntityComponentTemplate
            where TComponent : IEntityComponent, IEntityComponentWithTemplate<T>
        {
            if (!self.TryGetCurrentTemplate(out T template))
            {
                return;
            }

            self.LoadTemplate(template);
        }
    }
}