using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class TitleManager : SingletonBase<TitleManager>
{
    [SerializeField] private UI.TitleScreenPresenter titlePresenter;
    [SerializeField] private UI.StageSelectScreenPresenter stageSelectScreenPresenter;
    [SerializeField] private UI.CreditDialogPresenter creditDialogPresenter;

    // Start is called before the first frame update
    void Start()
    {
        titlePresenter.Initialize();
        stageSelectScreenPresenter.Initialize();
        creditDialogPresenter.Initialize();
    }
}
