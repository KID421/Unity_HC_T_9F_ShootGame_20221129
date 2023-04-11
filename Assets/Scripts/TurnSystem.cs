using UnityEngine;

namespace KID
{
    /// <summary>
    /// 回合系統
    /// 1. 玩家回合：玩家可以發射彈珠 V
    /// 2. 玩家發射後就不能動 V
    /// 3. 等待所有彈珠回收
    /// 4. 敵人回合：往前移動
    /// 5. 生成下一波敵人
    /// </summary>
    public class TurnSystem : MonoBehaviour
    {
        [SerializeField, Header("要回收的彈珠名稱")]
        private string nameMarble = "彈珠";

        private ControlSystem controlSystem;
        // 回收彈珠數量
        private int countRecycle;

        private void Awake()
        {
            controlSystem = FindObjectOfType<ControlSystem>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name.Contains(nameMarble))
            {
                countRecycle++;
                // print($"<color=#9966ff>回收彈珠：{ countRecycle }</color>");

                // 刪除回收的彈珠
                Destroy(other.gameObject);

                // 如果 可發射數量 等於 回收數量 就換敵人回合
                if (controlSystem.countMarbleTotal == countRecycle)
                {
                    // print($"<color=#9966ff>敵人回合</color>");
                    EnemyTurn();
                }
            }
        }

        /// <summary>
        /// 敵人回合：所有有 MoveSystem 執行移動
        /// </summary>
        private void EnemyTurn()
        {
            // FOOT 透過類型尋找物件，複數 FindObjectsOfType 要有 s
            MoveSystem[] moveSystems = FindObjectsOfType<MoveSystem>();

            // 執行取得移動系統陣列，讓每個移動系統開始移動
            for (int i = 0; i < moveSystems.Length; i++)
            {
                moveSystems[i].StartMove();
            }
        }
    }
}
