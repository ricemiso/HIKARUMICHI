using UniRx;
using UnityEngine;

namespace UI
{
    public class MainGamePresenter : PresenterBase<MainGameScreenView>
    {
        private StageDataManager _stageDataManager => StageDataManager.Instance;
        protected override void Bind()
        {
            base.Bind();

            BindTime();
            BindCoin();

            void BindTime()
            {
                _stageDataManager.ElapsedTimePrep
                    .TakeUntilDestroy(this)
                    .Subscribe(value =>
                    {
                        _View.SetTimeText(value);
                    });
            }

            void BindCoin()
            {
                _stageDataManager.CoinIdPrep
                    .TakeUntilDestroy(this)
                    .Where(value => value >= 0)
                    .Subscribe(value =>
                    {
                        _View.SetGetCoinColor(value);
                    });
            }
        }
    }
}
