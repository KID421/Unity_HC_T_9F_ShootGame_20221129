using UnityEngine;

namespace KID
{
    /// <summary>
    /// 基本資料：血量與攻擊力
    /// </summary>
    public class DataBasic : MonoBehaviour
    {
        [Header("血量"), Range(0, 10000)]
        public float hp = 200;
        [Header("攻擊力"), Range(10, 5000)]
        public float attack = 50;
    }
}
