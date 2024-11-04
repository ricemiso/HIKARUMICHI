using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// シーンの変更を行うクラス
/// </summary>
public class SceneChanger : SingletonBase<SceneChanger>
{
    [SerializeField]
    private string[] sceneNames;

    [SerializeField]
    private SCENE_DEF nextScene_Debug;

    [SerializeField]
    private int nextSceneIndex_Debug;

    [SerializeField]
    private StageDataSO stageData;

    private SCENE_DEF currentScene;

    /// <summary>
    /// 次に読み込むシーン
    /// </summary>
    private SCENE_DEF nextScene;

    public enum SCENE_DEF
    {
        Title = 0,
        Stage_1,
        Stage_2,
        Stage_3,
        Max
    }

    protected override void Awake()
    {
        base.Awake();
        //DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        if ((int)SCENE_DEF.Max > sceneNames.Length)
        {
            Debug.LogError("[SceneChanger]読み込めるシーン以上に定義されています。");
            return;
        }

        currentScene = SCENE_DEF.Title;
    }

    /// <summary>
    /// シーンの変更
    /// </summary>
    /// <param name="scene"></param>
    public void ChangeScene(SCENE_DEF scene)
    {
        var sceneIndex = (int)scene;

        if (sceneIndex >= sceneNames.Length)
        {
            Debug.LogError("[SceneChanger]読み込めるシーン以上のインデックスを指定しています。");
            return;
        }
        // シーン名を取得
        var sceneName = sceneNames[sceneIndex];
        Debug.Log("[SceneChanger]シーンの遷移：" + sceneName);
        SceneManager.LoadScene(sceneName);

        // 現在のシーンを更新
        UpdateCurrentScene(scene);
        nextScene = scene;
    }

    /// <summary>
    /// シーンId指定でシーンの変更
    /// </summary>
    /// <param name="scene"></param>
    public void ChangeScene(int sceneId)
    {
        foreach (var stageData in stageData.StageDatas)
        {
            if (stageData.Id != sceneId)
            {
                continue;
            }

            var sceneType = stageData.SceneType;
            ChangeScene(sceneType);

            // 現在のシーンを更新
            UpdateCurrentScene(sceneType);

            return;
        }

        Debug.LogError($"[SceneChanger]sceneId:{sceneId} に対応するシーンが存在しません。");

    }


    /// <summary>
    /// 次のシーンに遷移
    /// </summary>
    public void ChangeNextScene()
    {
        if (++nextScene >= SCENE_DEF.Max)
        {
            Debug.Log("[SceneChanger]タイトルに戻ります。");
            nextScene = SCENE_DEF.Title;
        }

        ChangeScene(nextScene);

        // 現在のシーンを更新
        UpdateNextScene(nextScene);
    }


    /// <summary>
    /// 次のシーンに遷移
    /// </summary>
    public void ReloadCurrentScene()
    {
        ChangeScene(currentScene);
    }


    /// <summary>
    /// 現在のシーンを更新
    /// </summary>
    /// <param name="scene"></param>
    private void UpdateCurrentScene(SCENE_DEF scene)
    {
        currentScene = scene;
    }

    private void UpdateNextScene(SCENE_DEF scene)
    {
        if (scene >= SCENE_DEF.Max)
        {
            Debug.Log("[SceneChanger]NextScene をタイトルに戻ります。");
            nextScene = SCENE_DEF.Title;
        }
        else
        {
            nextScene = scene;
        }
    }

    #region デバッグ用関数
    /// <summary>
    /// デバッグ用のシーン遷移関数: nextScene_Debug で指定したシーンに遷移します。
    /// </summary>
    [ContextMenu("[Debug用]シーン遷移")]
    public void ChangeScene_Debug()
    {
        ChangeScene(nextScene_Debug);
    }

    /// <summary>
    /// デバッグ用のシーン遷移関数: 次のシーンに遷移。
    /// </summary>
    [ContextMenu("[Debug用]インデックス指定で次のシーン遷移")]
    public void ChangeNextScene_Debug()
    {
        ChangeScene(nextSceneIndex_Debug);
    }


    /// <summary>
    /// デバッグ用のシーン遷移関数: 現在のシーンを更新。
    /// </summary>
    [ContextMenu("[Debug用]現在のシーンを更新")]
    public void ReloadCurrentScene_Debug()
    {
        ReloadCurrentScene();
    }

    #endregion
}
