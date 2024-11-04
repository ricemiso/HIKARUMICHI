using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading;
using UnityEngine;

namespace UI
{
    [RequireComponent(typeof(DialogViewBase))]
    public class DialogPresenterBase<TView> : PresenterBase<TView>
        where TView: DialogViewBase
    {
        public override void Initialize()
        {
            base.Initialize();
            _View.RectTransform.localScale = CommonData.HIDE_SIZE;
            _View.ChangeInteractive(false);
        }

        public virtual async UniTask ShowAsync(CancellationToken? ctNull = null)
        {
            CancellationToken ct = ctNull ?? GetCt();
            await _View.ShowAsync(ct);
        }

        public virtual async UniTask HideAsync(CancellationToken? ctNull = null)
        {
            CancellationToken ct = ctNull ?? GetCt();
            await _View.HideAsync(ct);
        }
    }

    public class DialogViewBase: ViewBase
    {
        public virtual async UniTask ShowAsync(CancellationToken ct)
        {
            await PlayScaleAsync(CommonData.DEFAULT_SIZE, CommonData.ANIM_DURATION, Ease.InSine, ct);
            ChangeInteractive(true);
        }

        public virtual async UniTask HideAsync(CancellationToken ct)
        {
            ChangeInteractive(false);
            await PlayScaleAsync(CommonData.HIDE_SIZE, CommonData.ANIM_DURATION, Ease.OutSine, ct);
        }

        protected async UniTask PlayScaleAsync(Vector2 destination, float duration, Ease ease, CancellationToken ct)
        {
            RectTransform.DOComplete();

            await RectTransform
                .DOScale(destination, duration)
                .SetEase(ease)
                .ToUniTask(cancellationToken: ct);
        }
    }
}
