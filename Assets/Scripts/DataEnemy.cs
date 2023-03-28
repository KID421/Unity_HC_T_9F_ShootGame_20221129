using UnityEngine;

namespace KID
{
    /// <summary>
    /// 敵人資料：
    /// 1. 金幣預製物
    /// 2. 金幣掉落數量
    /// 3. 金幣掉落機率： 0 ~ 1，例如：80% 寫成 0.8
    /// </summary>
    [CreateAssetMenu(menuName = "KID/Data Enemy")]
    public class DataEnemy : DataBasic
    {
        [Header("金幣預製物")]
        public GameObject prefabCoin;
        [Header("掉落數量"), Range(1, 100)]
        public int coinDropCount = 10;
        [Header("掉落機率"), Range(0, 1)]
        public float coinProbability = 0.8f;
    }
}
