using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UI
{
    public class GameOverTest : MonoBehaviour
    {
        private float _time;
        [SerializeField]
        private StageSelectScreenPresenter _gameOverDialog;
        [SerializeField]
        private TitleScreenPresenter _titleScreenPresenter;
        [SerializeField]
        private CreditDialogPresenter _creditDialog;

        private void Awake()
        {
            //StageDataManager.Instance.StartTimer();
            _gameOverDialog.Initialize();
            _titleScreenPresenter.Initialize();
            _creditDialog.Initialize();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //StageDataManager.Instance.SetCoinListWithIndex(0, true);
            }
        }
    }
}
