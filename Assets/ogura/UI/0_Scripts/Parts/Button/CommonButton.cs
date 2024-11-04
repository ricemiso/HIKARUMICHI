using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI
{
    public class CommonButton : UIBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler, IPointerClickHandler
    {
        [SerializeField]
        private Button _button;
        [SerializeField]
        private RectTransform _rectTransform;

        private CancellationToken GetCt() => this.GetCancellationTokenOnDestroy();

        private void OnValidate()
        {
            _button = _button ?? GetComponent<Button>();
            _rectTransform = _rectTransform ?? GetComponent<RectTransform>();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            PlayScaleAsync(CommonData.DEFAULT_SIZE, Ease.OutSine, GetCt()).Forget();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            SoundManager.Instance.Play(SoundManager.Instance.Click);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            PlayScaleAsync(CommonData.PUSH_BUTTON_SIZE, Ease.InSine, GetCt()).Forget();
        }

        public void OnPointerUp(PointerEventData eventdata)
        {
            PlayScaleAsync(CommonData.DEFAULT_SIZE, Ease.OutSine, GetCt()).Forget();
        }

        private async UniTask PlayScaleAsync(Vector2 size, Ease ease, CancellationToken ct)
        {
            _rectTransform.DOComplete();

            await _rectTransform
                .DOScale(size, CommonData.ANIM_DURATION)
                .SetEase(ease)
                .ToUniTask(cancellationToken: ct);
        }
    }
}

