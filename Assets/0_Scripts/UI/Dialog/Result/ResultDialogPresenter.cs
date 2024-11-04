using Cysharp.Threading.Tasks;
using System.Threading;

using UniRx;
using UnityEngine;
using UnityEngine.Events;

namespace UI
{
    public class ResultDialogPresenter : DialogPresenterBase<ResultDialogView>
    {
        private StageDataManager _stageDataManager => StageDataManager.Instance;


        protected override void Bind()
        {
            base.Bind();

            CommonData.BindNextButton(_View.NextStageButton, GameObject);
            CommonData.BindRestartButton(_View.RestartButton, GameObject);
            CommonData.BindTitleButton(_View.TitleButton, GameObject);

            GoalManager.Instance.IsGoalProp.
            TakeUntilDestroy(this).Where(value => value).Subscribe(_ => ShowAsync());
        }

        public override async UniTask ShowAsync(CancellationToken? ctNull = null)
        {
            SetTime(_stageDataManager.ElapsedTime);
            SetGetCoins(_stageDataManager.CoinList);

            await base.ShowAsync(ctNull);
        }

        public void SetTime(Common.Time time)
        {
            _View.SetTime(time);
        }

        public void SetGetCoins(bool[] isGetCoins)
        {
            _View.SetGetCoins(isGetCoins);
        }
    }
}