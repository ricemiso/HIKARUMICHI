using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    [RequireComponent(typeof(CanvasGroup))]
    public class ViewBase : UIBehaviour
    {
        [SerializeField]
        private GameObject _gameObject;
        public GameObject GameObject => _gameObject;
        [SerializeField]
        private RectTransform _rectTransform;
        public RectTransform RectTransform => _rectTransform;

        [SerializeField]
        private CanvasGroup _canvasGroup;
        public CanvasGroup CanvasGroup => _canvasGroup;

        protected virtual void OnValidate()
        {
            _gameObject = _gameObject ?? gameObject;
            _rectTransform = _rectTransform ?? GetComponent<RectTransform>();
            _canvasGroup = _canvasGroup ?? GetComponent<CanvasGroup>();
        }

        public virtual void Initialize()
        {

        }

        public void ChangeInteractive(bool isInteractive)
        {
            CanvasGroup.interactable = isInteractive;
            CanvasGroup.blocksRaycasts = isInteractive;
        }
    }

    public class PresenterBase<TView>: UIBehaviour
        where TView : ViewBase
    {
        [SerializeField]
        protected TView _View;

        public GameObject GameObject => _View.GameObject;

        protected CancellationToken GetCt() => this.GetCancellationTokenOnDestroy();

        protected virtual void OnValidate()
        {
            _View = _View ?? GetComponent<TView>();
        }

        public virtual void Initialize()
        {
            _View.Initialize();

            SetEvent();
            Bind();
        }

        protected virtual void SetEvent()
        {

        }

        protected virtual void Bind()
        {

        }
    }
}
