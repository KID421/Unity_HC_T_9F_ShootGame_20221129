using UnityEngine;

namespace KID
{
    /// <summary>
    /// 學習列舉 enumeration
    /// </summary>
    public class LearnEnum : MonoBehaviour
    {
        // 1. 定義列舉
        // 2. 儲存在欄位

        // 範例：季節 - 春夏秋冬
        // 語法：修飾詞 列舉關鍵字 列舉名稱 { 選項 }
        public enum Season
        {
            Spring, Summer, Fall, Winter
        }

        public Season gameSeason;

        public Season season = Season.Summer;

        private void Awake()
        {
            season = Season.Winter; // 將 season 改為 冬天

            // 延遲呼叫 Invoke("方法名稱"，延遲秒數)；
            Invoke("Spring", 5);                        // 五秒後呼叫春天方法
        }

        // 遊戲開始後五秒 season 變成春天
        private void Spring()
        {
            season = Season.Spring;
        }
    }
}
