using UniRx;
using UnityEngine;

public class GameOverManager : SingletonBase<GameOverManager>
{
    private BoolReactiveProperty _isGameOverProp = new();
    public IReadOnlyReactiveProperty<bool> IsGameOverProp => _isGameOverProp;
    public bool IsGameOver => _isGameOverProp.Value;
    public void SetGameOver(bool isGameOver)
    {
        _isGameOverProp.Value = isGameOver;
        if(isGameOver)
        {
            SoundManager.Instance.Play(SoundManager.Instance.GameOver);
            Cursor.lockState = CursorLockMode.None;
            StageDataManager.Instance.CancelTimer();
        }
        

    }
}
