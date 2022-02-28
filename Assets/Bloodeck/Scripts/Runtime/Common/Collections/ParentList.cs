using System.Collections.Generic;
using niscolas.UnityUtils.Core.Extensions;

namespace Bloodeck
{
    public class ParentList<TBase, TChild> : ParentCollection<TBase, TChild>, IList<TBase> where TChild : TBase
    {
        public ParentList() { }
        public ParentList(IEnumerable<TChild> content) : base(content) { }
        public ParentList(params TChild[] content) : base(content) { }

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