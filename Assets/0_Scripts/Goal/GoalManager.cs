using UniRx;

public class GoalManager : SingletonBase<GoalManager>
{
    private StageDataManager _stageDatamanager => StageDataManager.Instance;

    private BoolReactiveProperty _isGoalProp = new();
    public IReadOnlyReactiveProperty<bool> IsGoalProp => _isGoalProp;
    public bool IsGoal => _isGoalProp.Value;

    public void SetGoal(bool isGoal)
    {
        if (isGoal)
        {
            _stageDatamanager.CancelTimer();
            var clearData = new ClearData(_stageDatamanager.ElapsedTime, _stageDatamanager.CoinList);
            GameManager.Instance.SaveClearData(clearData);
            SoundManager.Instance.Play(SoundManager.Instance.GameClear);
        }

        _isGoalProp.Value = isGoal;
    }
}
