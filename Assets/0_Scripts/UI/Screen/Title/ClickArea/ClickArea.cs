using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class ClickArea : UIBehaviour, IPointerClickHandler
    {
        private BoolReactiveProperty _isClick = new();
        public IReadOnlyReactiveProperty<bool> IsClick => _isClick;

        public void OnPointerClick(PointerEventData eventData)
        {
            _isClick.Value = true;
        }

        public void ResetValue()
        {
            _isClick.Value = false;
        }
    }
}
