using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class TitleScreenView : ViewBase
    {
        [SerializeField]
        private Slider _masterVolumeSlider;
        public Slider MasterVolumeSlider => _masterVolumeSlider;
        [SerializeField]
        private Slider _bgmVolumeSlider;
        public Slider BgmVolumeSlider => _bgmVolumeSlider;
        [SerializeField]
        private Slider _seVolumeSlider;
        public Slider SeVolumeSlider => _seVolumeSlider;
        [SerializeField]
        private Button _creditButton;
        public Button CreditButton => _creditButton;
    }
}
