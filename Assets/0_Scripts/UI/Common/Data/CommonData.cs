using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public static class CommonData
    {
        /// <summary>
        /// 非表示の色
        /// </summary>
        public readonly static Color HIDE_COLOR = Color.clear;

        // コインの色
        public readonly static Color GET_COIN_COLOR = Color.yellow;
        public readonly static Color UN_GET_COIN_COLOR = Color.white;

        //透明度
        public readonly static float SHOW_ALPHA = 1.0f;
        public readonly static float HIDE_ALPHA = 0.0f;

        // UIのサイズ
        public readonly static Vector2 DEFAULT_SIZE = Vector2.one;
        public readonly static Vector2 HIDE_SIZE = Vector2.zero;

        // ボタンのサイズ
        public readonly static Vector2 PUSH_BUTTON_SIZE = Vector2.one * 0.8f;

        /// <summary>
        /// UIのアニメーションデフォルト時間
        /// </summary>
        public readonly static float ANIM_DURATION = 0.1f;

        /// <summary>
        /// ボタンを押したときの処理焼き付け
        /// </summary>
        /// <param name="button">対象のボタン</param>
        /// <param name="gameObject">生存を紐づけるオブジェクト</param>
        /// <param name="action">ボタンを押したときの処理</param>
        public static void BindButtonClick(Button button, GameObject gameObject, Action action)
        {
            button
                .OnClickAsObservable()
                .TakeUntilDestroy(gameObject)
                .Subscribe(_ =>
                {
                    action();
                });
        }

        //ボタンのクリック時の処理

        public static void BindRestartButton(Button button, GameObject gameObject)
        {
            BindButtonClick(button, gameObject, () =>
            {
                SceneChanger.Instance.ReloadCurrentScene();
            });
        }

        public static void BindNextButton(Button button, GameObject gameObject)
        {
            BindButtonClick(button, gameObject, () =>
            {
                SceneChanger.Instance.ChangeNextScene();
            });
        }

        public static void BindTitleButton(Button button, GameObject gameObject)
        {
            CommonData.BindButtonClick(button, gameObject, () =>
            {
                SceneChanger.Instance.ChangeScene(SceneChanger.SCENE_DEF.Title);
            });
        }

        //コイン関連の処理

        public static Image[] GetCoinsByParent(Image[] coinImages, Transform parent)
        {
            if (coinImages.Length != 0 || parent is null)
            {
                return coinImages;
            }

            var count = parent.childCount;
            var coins = new Image[count];

            for (int i = 0; i < count; i++)
            {
                coins[i] = parent.GetChild(i).GetComponent<Image>();
            }

            return coins;
        }
        public static void HideCoinsColor(Image[] coins)
        {
            foreach (var coin in coins)
            {
                coin.color = HIDE_COLOR;
                coin.gameObject.SetActive(false);
            }
        }

        public static void ResetCoinsColor(Image[] coins)
        {
            foreach (var coin in coins)
            {
                coin.color = UN_GET_COIN_COLOR;
            }
        }
    }
}
