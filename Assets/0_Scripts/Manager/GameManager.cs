using UnityEngine;

public class GameManager : SingletonBase<GameManager>
{
    [SerializeField]
    private StageDataSO _stageDataSO;
    public StageData[] StageDatas => _stageDataSO.StageDatas;

    private ClearData[] _clearDatas;
    public ClearData[] ClearDatas => _clearDatas;

    private int _currentStageIndex;
    bool _isfirst = false;


    protected override void Awake()
    {
        base.Awake();
        
        DontDestroyOnLoad(this);

        InitializeData();
    }

    private void InitializeData()
    {
        int length = StageDatas.Length;
        _clearDatas = new ClearData[length];

        for (int i=0; i< length; i++)
        {
            bool[] isGetCoins = new bool[StageDatas[i].CoinCount];

            _clearDatas[i] = new ClearData(new Common.Time(0), isGetCoins);
        }
    }

    public void SetPlayStageId(int id)
    {
        _currentStageIndex = id;
    }

    public void SaveClearData(ClearData clearData)
    {
        var currentData = _clearDatas[_currentStageIndex];
        Common.Time time = currentData.ClearTime.Second > clearData.ClearTime.Second || currentData.ClearTime.Second == 0 ? clearData.ClearTime : currentData.ClearTime;

        int length = clearData.IsGetCoins.Length;
        bool[] isCoins = new bool[length];
        for(int i=0; i< length;i++)
        {
            isCoins[i] = clearData.IsGetCoins[i] || currentData.IsGetCoins[i];
        }

        _clearDatas[_currentStageIndex] = new ClearData(time, isCoins);
    }
}

public class ClearData
{
    private bool[] _isGetCoins;
    public bool[] IsGetCoins => _isGetCoins;
    private Common.Time _clearTime = new(0);
    public Common.Time ClearTime => _clearTime;

    public ClearData(Common.Time time, bool[] isGetCoins)
    {
        _clearTime = time;
        _isGetCoins = isGetCoins;
    }
}
