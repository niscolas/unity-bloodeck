using System;
using UnityEngine;

namespace Lingua.Extras
{
    [Serializable]
    public class SimpleTextBox : INoContextText
    {
        [NaughtyAttributes.ResizableTextArea, SerializeField]
        private string _text;
        
        public string Get(EmptyTextContext context)
        {
            return _text;
        }
    }
}