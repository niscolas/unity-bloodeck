using niscolas.UnityUtils.Core.Extensions;

namespace Bloodeck
{
    public class SimpleTemplateLoader<T>
    {
        public static void InitializationLoadTemplate(ITemplatable<T> templatable)
        {
            if (CheckShouldLoadTemplateOnInitialization(templatable))
            {
                templatable.LoadTemplate(templatable.TemplateToLoad);
            }
        }

        private static bool CheckShouldLoadTemplateOnInitialization(ITemplatable<T> templatable)
        {
            return !templatable.TemplateToLoad.IsUnityNull() &&
                   !templatable.TemplateToLoad.Equals(templatable.LoadedTemplate);
        }
    }
}