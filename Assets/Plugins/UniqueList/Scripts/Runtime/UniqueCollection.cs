// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Collections.ObjectModel;
// using UnityEngine;
//
// namespace UniqueList
// {
//     [Serializable]
//     public abstract class UniqueCollection<T> :
//         List<T>,
//         ISerializationCallbackReceiver
//     {
//         protected abstract List<T>
//
//         public void OnAfterDeserialize()
//         {
//             Clear();
//
//             for (int i = 0; i < _listContent.Count; i++)
//             {
//                 TKey key = _listContent[i].Key;
//
//                 if (key != null && !ContainsKey(key))
//                 {
//                     Add(_listContent[i].Key, _listContent[i].Value);
//                 }
//                 else if (!ContainsKey(_defaultKey))
//                 {
//                     Add(_defaultKey, _listContent[i].Value);
//                 }
//             }
//         }
//
//         public void OnBeforeSerialize()
//         {
//             _listContent.Clear();
//             foreach ((TKey key, TValue value) in this)
//             {
//                 _listContent.Add(new TKeyValuePair
//                 {
//                     Key = key,
//                     Value = value
//                 });
//             }
//         }
//     }
// }