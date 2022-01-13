using niscolas.UnityUtils.Core;
using TMPro;
using UnityEngine;

namespace Bloodeck
{
    public class CardAttackDisplayMonoBehaviour : CachedMB
    {
        [SerializeField]
        private TMP_Text _text;

        [SerializeField]
        private CardAttackMB _cardAttack;

        private void OnEnable()
        {
            _text.SetText(FormatText());
        }

        private string FormatText()
        {
            return _cardAttack.AttackValue.ToString();
        }
    }
}