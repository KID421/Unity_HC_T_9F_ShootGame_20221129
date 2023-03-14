using UnityEngine;

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
        private void Spawn()
        {
            int random = Random.Range(countMin, countMax + 1);
            print($"<color=#ff6699>要生成的怪物數量：{ random }</color>");

            int countToDelete = boxSecond.Length - random;
            print($"<color=#ff6699>要刪除的格子數量：{ countToDelete }</color>");
        }
        #endregion
    }
}
