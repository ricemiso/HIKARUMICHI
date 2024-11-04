using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace UI
{
    public class CreditDialogPresenter : DialogPresenterBase<CreditDialogView>
    {
        protected override void Bind()
        {
            base.Bind();

            BindCloseButton();

            void BindCloseButton()
            {
                _View.CloseButton
                    .OnClickAsObservable()
                    .TakeUntilDestroy(this)
                    .Subscribe(_ =>
                    {
                        HideAsync().Forget();
                    });
            }
        }
    }
}
