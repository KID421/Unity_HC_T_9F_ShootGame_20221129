using UnityEngine;

namespace KID
{
    /// <summary>
    /// 傷害系統基底：父類別
    /// </summary>
    public class DamageSystemBasic : MonoBehaviour
    {
        [SerializeField, Header("基本資料")]
        private DataBasic data;

        /// <summary>
        /// 受傷
        /// </summary>
        /// <param name="damage">受到的傷害值</param>
        private void GetDamage(float damage)
        {

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
