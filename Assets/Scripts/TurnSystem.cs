using TMPro;
using UnityEngine;

namespace KID
{
    /// <summary>
    /// 回合系統
    /// 1. 玩家回合：玩家可以發射彈珠 V
    /// 2. 玩家發射後就不能動 V
    /// 3. 等待所有彈珠回收 V
    /// 4. 敵人回合：往前移動 V
    /// 5. 生成下一波敵人 V
    /// </summary>
    public class TurnSystem : MonoBehaviour
    {
        [SerializeField, Header("要回收的彈珠名稱")]
        private string nameMarble = "彈珠";
        [SerializeField, Header("敵人回合移動時間"), Range(0, 3)]
        private float timeMove = 1.2f;
        [SerializeField, Header("敵人生成時間"), Range(0, 3)]
        private float timeSpawn = 0.5f;
        [SerializeField, Header("文字層數")]
        private TextMeshProUGUI textFloor;
        [SerializeField, Header("最大層數"), Range(1, 50)]
        private int maxFloor = 3;

        private int floor = 1;
        // 回收彈珠數量
        private int countRecycle;
        private ControlSystem controlSystem;
        private SpawnSystem spawnSystem;

        // 吃到的彈珠數量
        // HideInInspector 將欄位隱藏 (大部分搭配 public)
        [HideInInspector]
        public int countEatMarble;

        private void Awake()
        {
            controlSystem = FindObjectOfType<ControlSystem>();
            spawnSystem = FindObjectOfType<SpawnSystem>();
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

            Invoke("DelaySpawn", timeMove);
        }

        /// <summary>
        /// 延遲生成完成後換玩家回合
        /// </summary>
        private void DelaySpawn()
        {
            // 如果層數 < 最大層數 才會生成
            if (floor < maxFloor)
            {
                spawnSystem.Spawn();
                floor++;                            // 層數遞增
                textFloor.text = floor.ToString();  // 更新層數文字介面
            }
            Invoke("PlayerTurn", timeSpawn);
        }

        /// <summary>
        /// 玩家回合：開啟控制器、回收彈珠數量歸零
        /// </summary>
        private void PlayerTurn()
        {
            controlSystem.enabled = true;
            countRecycle = 0;

            // 更新可發射的彈珠數量
            controlSystem.countMarbleTotal += countEatMarble;
            countEatMarble = 0;
        }
    }
}
