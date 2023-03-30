using UnityEngine;

namespace KID
{
    /// <summary>
    /// 敵人受傷系統：子類別
    /// 1. 碰到彈珠會受傷
    /// 2. 死亡會機率性掉落金幣
    /// 3. 死亡會刪除物件
    /// </summary>
    public class DamageEnemy : DamageSystemBasic
    {
        private string nameMarble = "彈珠";

        // => Lambda 黏巴達
        // 轉換資料類型
        // (想要轉換的資料類型)資料名稱
        private DataEnemy dataEnemy => (DataEnemy)data;

        // 1. 怪物與彈珠都要有 Collider
        // 2. 怪物與彈珠其中一個要有 Rigidbody
        // 3. 兩者都沒有勾 Is Trigger
        private void OnCollisionEnter(Collision collision)
        {
            print($"<color=#6699ff>碰到的物件 { collision.gameObject } </color>");

            // 如果 碰到物件的名稱 包含 彈珠 才會受傷
            // 包含 Contains 可放在字串後面
            if (collision.gameObject.name.Contains(nameMarble))
            {
                GetDamage(100);
            }
        }

        // override 加上空格後可以選取可覆寫的內容
        protected override void Dead()
        {
            // base 父類別原有的內容
            base.Dead();

            // 呼叫掉落金幣
            DropCoin();

            // 刪除此物件
            Destroy(gameObject);
        }

        /// <summary>
        /// 掉落金幣
        /// </summary>
        private void DropCoin()
        {
            // 判定是否在掉落機率內
            if (Random.value <= dataEnemy.coinProbability)
            {
                for (int i = 0; i < dataEnemy.coinDropCount; i++)
                {
                    int angle = Random.Range(0, 360);

                    // 就生成金幣在怪物頭上
                    Instantiate(
                        dataEnemy.prefabCoin,                           // 金幣
                        transform.position + new Vector3(0, 1.5f, 0),   // 座標 + 位移
                        Quaternion.Euler(90, angle, 0));                // 歐拉角度(X，Y，Z)
                }
            }
        }
    }
}
