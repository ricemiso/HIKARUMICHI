using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �V�[���̕ύX���s���N���X
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
    /// ���ɓǂݍ��ރV�[��
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
            Debug.LogError("[SceneChanger]�ǂݍ��߂�V�[���ȏ�ɒ�`����Ă��܂��B");
            return;
        }

        currentScene = SCENE_DEF.Title;
    }

    /// <summary>
    /// �V�[���̕ύX
    /// </summary>
    /// <param name="scene"></param>
    public void ChangeScene(SCENE_DEF scene)
    {
        var sceneIndex = (int)scene;

        if (sceneIndex >= sceneNames.Length)
        {
            Debug.LogError("[SceneChanger]�ǂݍ��߂�V�[���ȏ�̃C���f�b�N�X���w�肵�Ă��܂��B");
            return;
        }
        // �V�[�������擾
        var sceneName = sceneNames[sceneIndex];
        Debug.Log("[SceneChanger]�V�[���̑J�ځF" + sceneName);
        SceneManager.LoadScene(sceneName);

        // ���݂̃V�[�����X�V
        UpdateCurrentScene(scene);
        nextScene = scene;
    }

    /// <summary>
    /// �V�[��Id�w��ŃV�[���̕ύX
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

            // ���݂̃V�[�����X�V
            UpdateCurrentScene(sceneType);

            return;
        }

        Debug.LogError($"[SceneChanger]sceneId:{sceneId} �ɑΉ�����V�[�������݂��܂���B");

    }


    /// <summary>
    /// ���̃V�[���ɑJ��
    /// </summary>
    public void ChangeNextScene()
    {
        if (++nextScene >= SCENE_DEF.Max)
        {
            Debug.Log("[SceneChanger]�^�C�g���ɖ߂�܂��B");
            nextScene = SCENE_DEF.Title;
        }

        ChangeScene(nextScene);

        // ���݂̃V�[�����X�V
        UpdateNextScene(nextScene);
    }


    /// <summary>
    /// ���̃V�[���ɑJ��
    /// </summary>
    public void ReloadCurrentScene()
    {
        ChangeScene(currentScene);
    }


    /// <summary>
    /// ���݂̃V�[�����X�V
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
            Debug.Log("[SceneChanger]NextScene ���^�C�g���ɖ߂�܂��B");
            nextScene = SCENE_DEF.Title;
        }
        else
        {
            nextScene = scene;
        }
    }

    #region �f�o�b�O�p�֐�
    /// <summary>
    /// �f�o�b�O�p�̃V�[���J�ڊ֐�: nextScene_Debug �Ŏw�肵���V�[���ɑJ�ڂ��܂��B
    /// </summary>
    [ContextMenu("[Debug�p]�V�[���J��")]
    public void ChangeScene_Debug()
    {
        ChangeScene(nextScene_Debug);
    }

    /// <summary>
    /// �f�o�b�O�p�̃V�[���J�ڊ֐�: ���̃V�[���ɑJ�ځB
    /// </summary>
    [ContextMenu("[Debug�p]�C���f�b�N�X�w��Ŏ��̃V�[���J��")]
    public void ChangeNextScene_Debug()
    {
        ChangeScene(nextSceneIndex_Debug);
    }


    /// <summary>
    /// �f�o�b�O�p�̃V�[���J�ڊ֐�: ���݂̃V�[�����X�V�B
    /// </summary>
    [ContextMenu("[Debug�p]���݂̃V�[�����X�V")]
    public void ReloadCurrentScene_Debug()
    {
        ReloadCurrentScene();
    }

    #endregion
}
