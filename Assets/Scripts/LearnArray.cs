using UnityEngine;

namespace KID
{
    /// <summary>
    /// 學習陣列
    /// 儲存多個相同類型的資料
    /// </summary>
    public class LearnArray : MonoBehaviour
    {
        // 需求：經驗值
        // Lv1 100
        // Lv2 10000
        // Lv3 1000000

        public int lv1 = 100;
        public int lv2 = 10000;
        public int lv3 = 1000000;

        // 陣列語法：
        // 修飾詞 類型[] 名稱 指定 預設值；
        public int[] lv;

        // 道具陣列，五格
        public GameObject[] props = new GameObject[5];

        // 武器陣列，三格，刀子、石頭、樹枝
        public string[] weapons = { "刀子", "石頭", "樹枝" };

        private void Awake()
        {
            // 存取陣列資料
            // 取得
            // 陣列名稱[編號]
            print("第二個武器：" + weapons[1]);
            // print("第三個武器：" + weapons[3]);   // 錯誤，編號超出範圍

            // 存放
            // 陣列名稱[編號] 指定 值
            weapons[2] = "寶特瓶";

            // 陣列的數量
            // 陣列名稱.長度
            print("武器的數量：" + weapons.Length);
            print("道具的數量：" + props.Length);
        }
    }
}
