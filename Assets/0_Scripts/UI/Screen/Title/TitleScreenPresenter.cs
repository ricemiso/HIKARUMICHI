using UnityEngine;
using UnityEngine.UI;
using UniRx;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;

namespace UI
{
    public class TitleScreenPresenter : PresenterBase<TitleScreenView>
    {
        [SerializeField]
        private StageSelectScreenPresenter _stageSelectScreen;
        [SerializeField]
        private CreditDialogPresenter _creditDialog;
        [SerializeField]
        private ClickArea _clickArea;
        private VolumeManager _volumeManager => VolumeManager.Instance;

        public override void Initialize()
        {
            base.Initialize();

            SetActive();
        }

        protected override void Bind()
        {
            base.Bind();

            BindSlider(_View.MasterVolumeSlider, VolumeManager.VolumeType.MASTER);
            BindSlider(_View.BgmVolumeSlider, VolumeManager.VolumeType.BGM);
            BindSlider(_View.SeVolumeSlider, VolumeManager.VolumeType.SE);

            BindClick();

            BindCreditButton();

            void BindSlider(Slider slider, VolumeManager.VolumeType type)
            {
                slider
                    .OnValueChangedAsObservable()
                    .TakeUntilDestroy(this)
                    .DistinctUntilChanged()
                    .Subscribe(value =>
                    {
                        _volumeManager.OnValueChanged(type, value);
                    });
            }

            void BindClick()
            {
                _clickArea.IsClick
                    .TakeUntilDestroy(this)
                    .DistinctUntilChanged()
                    .Where(value => value)
                    .Subscribe(_ =>
                    {
                        _View.ChangeInteractive(false);
                        SoundManager.Instance.Play(SoundManager.Instance.Click);
                        _stageSelectScreen.ShowAsync().Forget();
                    });
            }

            void BindCreditButton()
            {
                _View.CreditButton
                    .OnClickAsObservable()
                    .TakeUntilDestroy(this)
                    .Subscribe(_ =>
                    {
                        _creditDialog.ShowAsync().Forget();
                    });
            }
        }

        public void SetActive()
        {
            _View.ChangeInteractive(true);
            _clickArea.ResetValue();
        }
    }
}
