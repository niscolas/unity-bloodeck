using System;
using UnityEngine;

namespace Lingua
{
    [Serializable]
    public class SimpleTextField : INoContextText
    {
        [SerializeField]
        private string _text;
        
        public string Get(EmptyTextContext context)
        {
            return _text;
        }
    }
}