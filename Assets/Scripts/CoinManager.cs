using TMPro;
using UnityEngine;

namespace KID
{
    /// <summary>
    /// 金幣管理：紀錄玩家金幣總數並更新介面
    /// </summary>
    public class CoinManager : MonoBehaviour
    {
        [SerializeField, Header("文字金幣數量")]
        private TextMeshProUGUI textCoinCount;

        /// <summary>
        /// 金幣總數
        /// </summary>
        private int coinTotal;

        /// <summary>
        /// 更新金幣數量：每次加一
        /// </summary>
        public void UpdateCoinCount()
        {
            // 金幣總數遞增
            coinTotal++;
            // 金幣介面更新
            textCoinCount.text = coinTotal.ToString();

            // 先取得要播放的聲音再播放
            AudioClip sound = SoundSystem.instance.soundEatCoin;
            SoundSystem.instance.PlaySound(0.1f, 0.2f, sound);
        }
    }
}
