using System;
using System.Collections.Generic;
using niscolas.UnityUtils.Core.Extensions;

namespace Bloodeck
{
    [Serializable]
    public class InjectableParentList<TBase, TChild> : InjectableParentCollection<TBase, TChild>, IList<TBase>
        where TChild : TBase
    {
        public InjectableParentList() { }
        public InjectableParentList(IEnumerable<TChild> content) : base(content) { }
        public InjectableParentList(params TChild[] content) : base(content) { }

        public TBase this[int index]
        {
            get => _content[index];
            set => _content[index] = (TChild) value;
        }

        public int IndexOf(TBase item)
        {
            return _content.IndexOfParentItem(item);
        }

        public void Insert(int index, TBase item)
        {
            _content.InsertParentItem(index, item);
        }

        public void RemoveAt(int index)
        {
            _content.RemoveAt(index);
        }
    }
}