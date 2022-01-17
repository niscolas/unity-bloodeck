using System.Collections;
using System.Collections.Generic;

namespace Bloodeck
{
    public class Cards : ICards
    {
        public IEnumerator<ICard> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ICard item)
        {
            throw new System.NotImplementedException();
        }

        public void Clear()
        {
            throw new System.NotImplementedException();
        }

        public bool Contains(ICard item)
        {
            throw new System.NotImplementedException();
        }

        public void CopyTo(ICard[] array, int arrayIndex)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(ICard item)
        {
            throw new System.NotImplementedException();
        }

        public int Count { get; }
        public bool IsReadOnly { get; }
    }
}