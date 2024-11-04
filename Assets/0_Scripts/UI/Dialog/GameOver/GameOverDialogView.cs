using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class GameOverDialogView : DialogViewBase
    {
        [SerializeField]
        private Button _restartButton;
        public Button RestartButton => _restartButton;
        [SerializeField]
        private Button _titleButton;
        public Button TitleButton => _titleButton;
    }
}
