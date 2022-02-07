using System.Collections.Generic;
using System.Linq;
using niscolas.UnityUtils.Core;
using niscolas.UnityUtils.Core.Extensions;
using UnityAtoms.BaseAtoms;
using UnityEngine;

namespace Bloodeck
{
    public abstract class IdMB<T, TSelf, TCollection, TSelfCollection> : CachedMB
        where TSelf : IdMB<T, TSelf, TCollection, TSelfCollection>
        where TCollection : ICollection<T>, new()
        where TSelfCollection : ICollection<TSelf>, new()
    {
        [SerializeField]
        private StringReference _id;

        [SerializeField]
        private T _item;

        public string ID => _id.Value;

        public T Item => _item;

        public static readonly TCollection Items = new TCollection();
        public static readonly TSelfCollection All = new TSelfCollection();

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void SceneInit()
        {
            Items.Clear();
            All.Clear();
            
            TSelf[] all = FindObjectsOfType<TSelf>();
            all.ForEach(x =>
            {
                Items.Add(x.Item);
                All.Add(x);
            });
        }

        private void OnEnable()
        {
            if (All.Contains(this))
            {
                return;
            }

            Items.Add(_item);
            All.Add((TSelf) this);
        }

        private void OnDisable()
        {
            Items.Remove(_item);
            All.Remove((TSelf) this);
        }

        public static TSelf WithId(string id)
        {
            return All.FirstOrDefault(x => x.ID == id);
        }
    }
}