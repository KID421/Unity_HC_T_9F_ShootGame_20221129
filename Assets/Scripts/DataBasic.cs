using UnityEngine;

namespace KID
{
    /// <summary>
    /// 基本資料：血量與攻擊力
    /// </summary>
    
    // 腳本化物件 ScriptabaleObject
    // 1. 將繼承類別改為 ScriptabaleObject
    // 2. 添加類別屬性 CreateAssetMenu
    // 3. 屬性內使用 menuName 自訂菜單名稱

    [CreateAssetMenu(menuName = "KID/Data Basic")]
    public class DataBasic : ScriptableObject
    {
        [Header("血量"), Range(0, 10000)]
        public float hp = 200;
        [Header("攻擊力"), Range(10, 5000)]
        public float attack = 50;
    }
}
