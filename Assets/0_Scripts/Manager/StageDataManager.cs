using UnityEngine;
using UniRx.Triggers;
using UniRx;
public class StageDataManager : SingletonBase<StageDataManager>
{
    private bool[] _coinList = new bool[1];
    public bool[] CoinList => _coinList;
    public void SetCoinListWithIndex(int index,bool boolean)
    {
        _coinList[index] = boolean;

        if(boolean)
            _coinIdPrep.Value = index;
    }

    private ReactiveProperty<int> _coinIdPrep = new(-1);
    public IReadOnlyReactiveProperty<int> CoinIdPrep => _coinIdPrep;

    private float _elapsedTime = 0f;
    private ReactiveProperty<Common.Time> _elapsedTimePrep = new(new Common.Time(0));
    public IReadOnlyReactiveProperty<Common.Time> ElapsedTimePrep => _elapsedTimePrep; 
    public Common.Time ElapsedTime => _elapsedTimePrep.Value;

    CompositeDisposable compositeDisposable = new CompositeDisposable();


    public void StartTimer()
    {
        this.UpdateAsObservable()
            .Subscribe(_ =>
                {
                    _elapsedTimePrep.Value = new Common.Time(Time.deltaTime+ ElapsedTime.Second);
                })
            .AddTo(compositeDisposable);
    }

    public void CancelTimer()
    {
        compositeDisposable.Dispose();
    }
}
