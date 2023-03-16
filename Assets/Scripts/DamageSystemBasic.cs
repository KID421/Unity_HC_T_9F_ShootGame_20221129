using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace KID
{
    /// <summary>
    /// 傷害系統基底：父類別
    /// </summary>
    public class DamageSystemBasic : MonoBehaviour
    {
        #region 資料
        [SerializeField, Header("基本資料")]
        private DataBasic data;
        [SerializeField, Header("畫布傷害值")]
        private GameObject prefabDamage;
        [SerializeField, Header("圖片血條")]
        private Image imgHp;
        [SerializeField, Header("文字血量")]
        private TextMeshProUGUI textHp;

        private float hp, hpMax; 
        #endregion

        private void Awake()
        {
            // 解決腳本化物件資料不還原的方式
            // ※ 將腳本化物件儲存於欄位內
            hp = data.hp;

            // 取得血量最大值
            hpMax = data.hp;
            // 文字血量 的 文字 = 資料 的 血量 轉為字串
            textHp.text = data.hp.ToString();

            GetDamage(50);
        }

        /// <summary>
        /// 受傷
        /// </summary>
        /// <param name="damage">受到的傷害值</param>
        private void GetDamage(float damage)
        {
            // 扣血並且更新介面文字與圖片
            hp -= damage;

            textHp.text = hp.ToString();
            // 公式：當前血量 / 血量最大值 (0 ~ 1 百分比)
            imgHp.fillAmount = hp / hpMax;
        }

        /// <summary>
        /// 顯示傷害值物件
        /// </summary>
        private void ShowDamage()
        {

        }

        /// <summary>
        /// 死亡
        /// </summary>
        private void Dead()
        {

        }
    }
}
