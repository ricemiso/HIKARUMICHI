using Cysharp.Threading.Tasks;
using System.Threading;
using UniRx;
using UnityEngine;

namespace UI
{
    public class StageSelectScreenPresenter : PresenterBase<StageSelectScreenView>
    {
        [SerializeField]
        private TitleScreenPresenter titleScreen;
        private GameManager _gameManager => GameManager.Instance;

        public override void Initialize()
        {
            _View.CreateCell(_gameManager.StageDatas, _gameManager.ClearDatas);
            
            base.Initialize();

            _View.CanvasGroup.alpha = 0f;
            _View.ChangeInteractive(false);
        }

        protected override void Bind()
        {
            base.Bind();

            foreach(var cell in _View.StageCells)
            {
                BindCellClick(cell);
            }

            BindCloseButton();

            void BindCellClick(StageCell cell)
            {
                cell.ClickEvent
                    .TakeUntilDestroy(this)
                    .Subscribe(_ =>
                    {
                        GameManager.Instance.SetPlayStageId(cell.Id);
                        SceneChanger.Instance.ChangeScene(cell.SceneName);
                    });
            }

            void BindCloseButton()
            {
                _View.CloseButton
                    .OnClickAsObservable()
                    .TakeUntilDestroy(this)
                    .Subscribe(async _ =>
                    {
                        await HideAsync();
                        titleScreen.SetActive();
                    });
            }
        }

        public async UniTask ShowAsync(CancellationToken? ctNull = null)
        {
            CancellationToken ct = ctNull ?? GetCt();

            await _View.ShowAsync(ct);
        }

        public async UniTask HideAsync(CancellationToken? ctNull = null)
        {
            CancellationToken ct = ctNull ?? GetCt();

            await _View.HideAsync(ct);
        }
    }
}
