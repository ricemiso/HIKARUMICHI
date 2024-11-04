using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class StageSelectScreenView : ViewBase
    {
        [SerializeField]
        private Transform _cellParent;
        [SerializeField]
        private StageCell _cellBase;
        [SerializeField]
        private Button _closeButton;
        public Button CloseButton => _closeButton;

        private StageCell[] _stageCells;
        public StageCell[] StageCells => _stageCells;
        
        public void CreateCell(StageData[] stageDatas, ClearData[] clearDatas)
        {
            if(_cellParent.childCount > 0)
            {
                return;
            }

            int length = stageDatas.Length;
            _stageCells = new StageCell[length];


            for (int i =0; i< length; i++)
            {
                StageCell cell = Instantiate(_cellBase, _cellParent);
                cell.Initialize();
                cell.SetData(stageDatas[i], clearDatas[i]);

                _stageCells[i] = cell;
            }
        }

        public async UniTask ShowAsync(CancellationToken ct)
        {
            await PlayFade(CommonData.SHOW_ALPHA, CommonData.ANIM_DURATION, Ease.InSine, ct);
            ChangeInteractive(true);
        }

        public async UniTask HideAsync(CancellationToken ct)
        {
            ChangeInteractive(false);
            await PlayFade(CommonData.HIDE_ALPHA, CommonData.ANIM_DURATION, Ease.OutSine, ct);
        }

        private async UniTask PlayFade(float alpha, float duration, Ease ease, CancellationToken ct)
        {
            CanvasGroup.DOComplete();

            await CanvasGroup
                .DOFade(alpha, duration)
                .SetEase(ease)
                .ToUniTask(cancellationToken: ct);
        }
    }
}
