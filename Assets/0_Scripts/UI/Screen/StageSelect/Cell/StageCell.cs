using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UniRx;

namespace UI
{
    public class StageCell : UIBehaviour, IPointerClickHandler
    {
        [SerializeField]
        private TMP_Text _nameText;
        [SerializeField]
        private Image _image;
        [SerializeField]
        private Transform _coinParent;
        [SerializeField]
        private Image[] _coins;
        [SerializeField]
        private TMP_Text _clearTimeText;

        private int _id;
        public int Id => _id;
        private SceneChanger.SCENE_DEF _sceneType;
        public SceneChanger.SCENE_DEF SceneName => _sceneType;

        private Subject<Unit> _clickEvent = new();
        public ISubject<Unit> ClickEvent => _clickEvent;

        private void OnValidate()
        {
            _coins = CommonData.GetCoinsByParent(_coins, _coinParent);
        }

        public void Initialize()
        {
            CommonData.HideCoinsColor(_coins);
        }

        public void SetData(StageData data, ClearData clearData)
        {
            _id = data.Id;
            _sceneType = data.SceneType;

            _nameText.text = data.Name;
            _image.sprite = data.Image;
            
            for(int i=0; i< data.CoinCount; i++)
            {
                _coins[i].color = clearData.IsGetCoins[i] ? CommonData.GET_COIN_COLOR : CommonData.UN_GET_COIN_COLOR;
                _coins[i].gameObject.SetActive(true);
            }

            _clearTimeText.text = clearData.ClearTime.ToString();
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            SoundManager.Instance.Play(SoundManager.Instance.Click);
            _clickEvent.OnNext(default);
        }
    }
}
