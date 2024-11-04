using Cysharp.Text;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class ResultDialogView : DialogViewBase
    {
        [SerializeField]
        private TMP_Text _timeText;
        public TMP_Text TimeText => _timeText;
        [SerializeField]
        private Transform _coinParent;
        [SerializeField]
        private Image[] _coins;
        [SerializeField]
        private Button _nextStageButton;
        public Button NextStageButton => _nextStageButton;
        [SerializeField]
        private Button _restartButton;
        public Button RestartButton => _restartButton;
        [SerializeField]
        private Button _titleButton;
        public Button TitleButton => _titleButton;

        [SerializeField]
        private readonly string TIME_FORMAT = "Time: {0}";

        protected override void OnValidate()
        {
            base.OnValidate();

            _coins = CommonData.GetCoinsByParent(_coins, _coinParent);
        }

        public override void Initialize()
        {
            base.Initialize();

            CommonData.HideCoinsColor(_coins);
        }

        public void SetTime(Common.Time time)
        {
            _timeText.text = ZString.Format(TIME_FORMAT, time.ToString());
        }

        public void SetGetCoins(bool[] isGetCoins)
        {
            int activeCoinLength = isGetCoins.Length;

            if(activeCoinLength == 0)
            {
                return;
            }
            else if(activeCoinLength > _coins.Length)
            {
                Debug.Log("coins overfllow");
                return;
            }

            for(int i = 0; i<activeCoinLength; i++)
            {
                _coins[i].color = isGetCoins[i] ? CommonData.GET_COIN_COLOR : CommonData.UN_GET_COIN_COLOR;
                _coins[i].gameObject.SetActive(true);
            }
        }
    }
}
