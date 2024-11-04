using System;
using UnityEngine;

[CreateAssetMenu(fileName = "StageDataSO", menuName = "SO/Stage")]
public class StageDataSO : ScriptableObject
{
    [SerializeField]
    private StageData[] _stageDatas;
    public StageData[] StageDatas => _stageDatas;
}

[Serializable]
public class StageData
{
    [SerializeField]
    private int _id = 0;
    public int Id => _id;
    [SerializeField]
    private string _name;
    public string Name => _name;
    [SerializeField]
    private SceneChanger.SCENE_DEF _sceneType;
    public SceneChanger.SCENE_DEF SceneType => _sceneType;
    [SerializeField]
    private Sprite _image;
    public Sprite Image => _image;
    [SerializeField]
    private int _coinCount = 1;
    public int CoinCount => _coinCount;
}
