using System;
using System.Collections;
using System.Collections.Generic;
using niscolas.UnityUtils.Core;
using UnityEngine;

namespace Bloodeck
{
    [Serializable]
    public class CardTemplateSOCollection :
        ParentCollection<ICardTemplate, CardTemplateSO>, ICardTemplates { }
}