using System.Collections.Generic;

namespace Bloodeck
{
    public class Cards : InjectableCollection<ICard>, ICards
    {
        public Cards(ICollection<ICard> content) : base(content) { }
    }
}