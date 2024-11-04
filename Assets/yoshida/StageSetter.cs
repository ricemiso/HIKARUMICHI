using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSetter : MonoBehaviour
{
    [SerializeField] private UI.MainGamePresenter gamePresenter;
    [SerializeField] private UI.ResultDialogPresenter resultPresenter;
    [SerializeField] private UI.GameOverDialogPresenter gameOverPresenter;

    void Start()
    {
        gamePresenter.Initialize();
        resultPresenter.Initialize();
        gameOverPresenter.Initialize();
        StageDataManager.Instance.StartTimer();
    }

   
}
