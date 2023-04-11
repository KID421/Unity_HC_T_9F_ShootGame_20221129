using UnityEngine;
using System.Linq;                  // 陣列 轉 清單
using System.Collections.Generic;   // 清單

namespace KID
{
    /// <summary>
    /// 生成系統
    /// </summary>
    public class SpawnSystem : MonoBehaviour
    {
        #region 資料
        [SerializeField, Header("怪物陣列")]
        private GameObject[] prefabEnemys;
        [SerializeField, Header("第二排的格子")]
        private Transform[] boxSecond;
        [Header("生成怪物的最小與最大值")]
        [SerializeField, Range(2, 3)]
        private int countMin = 2;
        [SerializeField, Range(4, 6)]
        private int countMax = 5;
        [SerializeField, Header("要打亂的清單")]
        private List<Transform> boxRandom = new List<Transform>();
        [SerializeField, Header("可以吃的彈珠")]
        private GameObject prefabMarbleCanEat;
        #endregion

        #region 事件
        private void Awake()
        {
            Spawn();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 生成怪物
        /// </summary>
        public void Spawn()
        {
            int random = Random.Range(countMin, countMax + 1);
            // print($"<color=#ff6699>要生成的怪物數量：{ random }</color>");

            int countToDelete = boxSecond.Length - random;
            // print($"<color=#ff6699>要刪除的格子數量：{ countToDelete }</color>");

            // 1. 打亂清單
            // 清單 = 陣列.轉為清單
            boxRandom = boxSecond.ToList();
            // 新增隨機物件，處理隨機行為
            System.Random randomObject = new System.Random();
            // 打亂清單
            // 要打亂的清單 = 要打亂的清單.排序(每一筆資料 => 隨機物件.下一個()).轉回清單
            boxRandom = boxRandom.OrderBy(x => randomObject.Next()).ToList();

            // 2. 刪除清單不要的格子
            for (int i = 0; i < countToDelete; i++)
            {
                boxRandom.RemoveAt(0);
            }

            SpawnEnemy();
        }

        /// <summary>
        /// 生成敵人預製物
        /// </summary>
        private void SpawnEnemy()
        {
            // 生成所有敵人
            // 清單的數量：清單.Count
            for (int i = 0; i < boxRandom.Count; i++)
            {
                int random = Random.Range(0, prefabEnemys.Length);

                // 如果 i 等於 0 (第一隻) 就 生成 可以吃的彈珠
                if (i == 0)
                {
                    Instantiate(
                        prefabMarbleCanEat,
                        boxRandom[i].position + new Vector3(0, 2, 0),
                        Quaternion.identity);
                }
                // 否則
                else
                {
                    Instantiate(
                        prefabEnemys[random],
                        boxRandom[i].position + new Vector3(0, 2, 0),   // 座標
                        Quaternion.identity);
                }
            }
        }
        #endregion
    }
}
