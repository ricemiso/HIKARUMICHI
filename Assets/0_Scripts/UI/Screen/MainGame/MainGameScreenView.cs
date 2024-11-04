using Cysharp.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class MainGameScreenView : ViewBase
    {
        [SerializeField]
        private Transform _coinParent;
        [SerializeField]
        private Image[] _coins;

        [SerializeField]
        private TMP_Text _timeText;

        [SerializeField]
        private readonly string TIME_FORMAT = "{0}";

        protected override void OnValidate()
        {
            base.OnValidate();

            _coins = CommonData.GetCoinsByParent(_coins, _coinParent);
        }

        public override void Initialize()
        {
            base.Initialize();

            CommonData.ResetCoinsColor(_coins);
        }

        public void SetTimeText(Common.Time time)
        {
            _timeText.text = ZString.Format(TIME_FORMAT, time.ToString());
        }

        public void SetGetCoinColor(int id)
        {
            _coins[id].color = CommonData.GET_COIN_COLOR;
        }
    }
}
