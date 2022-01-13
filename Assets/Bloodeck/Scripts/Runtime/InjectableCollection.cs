using System.Collections.Generic;

namespace Bloodeck
{
    public class InjectableCollection<T> : CollectionWrapperBase<T>
    {
        protected sealed override ICollection<T> Content { get; set; }

        public InjectableCollection(ICollection<T> content)
        {
            Content = content;
        }
    }
}