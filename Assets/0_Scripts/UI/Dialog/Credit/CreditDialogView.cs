using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CreditDialogView : DialogViewBase
    {
        [SerializeField]
        private Button _closeButton;
        public Button CloseButton => _closeButton;
    }
}
