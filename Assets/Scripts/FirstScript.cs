// 單行註解：說明、解釋、開發者等等的文字敘述
// KID 2022.12.27 @3@
// 程式不會執行註解
// 程式上下、後面

using UnityEngine;  // 引用命名空間(倉庫) Unity 遊戲引擎 (API)

// ※ 腳本為藍圖，不會執行
// ※ 轉為物件才會執行，將腳本掛在場景物件上

// class 類別 等同於腳本 Script
// class 後面為腳本名稱，必須與檔案名稱相同
public class FirstScript : MonoBehaviour
{
    // Tab 縮排：大括號下面一行
    // 格式化：Ctrl + K D

    // 腳本都會有一對大括號，放置腳本內容

    // 事件：窗口，讓程式開發者可以使用跟控制的程式
    // 喚醒事件：播放遊戲時執行一次，大部分處理初始化
    // 例如：LOL 發 500 給所有玩家
    private void Awake()
    {
        // 此處要縮排兩次

        // 輸出：測試，將訊息顯示在 Unity 的控制台 Console (Ctrl+Shift+C)
        // 輸出("文字訊息")；
        print("哈囉，沃德 :D");
        print(1234567);
        // Rich Text
        print("<b>新年快樂~ 2023</b>");
        print("<color=yellow>耶~</color>");
        print("<color=#ff3355>粉紅色！</color>");
    }

    // 開始事件：在喚醒事件之後執行一次
    private void Start()
    {
        print("<color=red>這是開始事件！</color>");

        // 計算 1 + 2
        print("輸出 1 + 2");
        print($"輸出 {1 + 2}");
    }

    // 更新事件：一秒執行約 60 次，約 60 FPS
    private void Update()
    {
        print("<color=#3333ff>這是更新事件！</color>");
    }
}
