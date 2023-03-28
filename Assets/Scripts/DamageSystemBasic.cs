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

        [SerializeField, Header("動畫控制器")]
        private Animator ani;
        private string parDamage = "觸發受傷";
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

            GetDamage(99999);
        }

        /// <summary>
        /// 受傷
        /// </summary>
        /// <param name="damage">受到的傷害值</param>
        private void GetDamage(float damage)
        {
            // 設定觸發器(觸發器名稱)
            ani.SetTrigger(parDamage);

            // 扣血並且更新介面文字與圖片
            hp -= damage;

            // 如果 血量 <= 0 就呼叫死亡方法
            // 判斷式 如果只有一行程式可以省略大括號
            if (hp <= 0) Dead();

            textHp.text = hp.ToString();
            // 公式：當前血量 / 血量最大值 (0 ~ 1 百分比)
            imgHp.fillAmount = hp / hpMax;

            ShowDamage(damage);
        }

        /// <summary>
        /// 顯示傷害值物件
        /// </summary>
        private void ShowDamage(float damage)
        {
            // 生成的物件 = 生成傷害值物件
            GameObject temp = Instantiate(
                prefabDamage,
                transform.position + new Vector3(0, 1, 0),
                Quaternion.Euler(60, 0, 0));

            // 取得生成的物件 子物件 並更新 文字
            // transform.GetChild(0) 取得第一個子物件
            temp.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "-" + damage;

            // 一秒後 刪除 生成的物件
            // 刪除(物件，延遲時間)
            Destroy(temp, 1);
        }

        /// <summary>
        /// 死亡
        /// </summary>
        private void Dead()
        {
            hp = 0;         // 血量歸零
        }
    }
}
