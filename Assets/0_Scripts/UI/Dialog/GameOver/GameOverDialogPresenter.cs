using UniRx;
using Cysharp.Threading.Tasks;

namespace UI
{
    public class GameOverDialogPresenter : DialogPresenterBase<GameOverDialogView>
    {
        protected override void Bind()
        {
            base.Bind();

            CommonData.BindRestartButton(_View.RestartButton, GameObject);
            CommonData.BindTitleButton(_View.TitleButton, GameObject);

            GameOverManager.Instance.IsGameOverProp.TakeUntilDestroy(this).Where(value => value).Subscribe(_ => ShowAsync().Forget());
        }
    }
}
