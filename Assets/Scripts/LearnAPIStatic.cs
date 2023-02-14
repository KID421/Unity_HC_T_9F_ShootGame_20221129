using UnityEngine;

namespace KID
{
    /// <summary>
    /// 學習 API 靜態 Static
    /// Static 靜態：遊戲一開始就儲存在記憶體內的資料
    /// 例如：隨機
    /// </summary>
    public class LearnAPIStatic : MonoBehaviour
    {
        private void Awake()
        {
            // 靜態屬性 Static Properties
            // 1. 取得靜態屬性 Get
            // 語法：
            // 類別名稱.靜態屬性名稱
            print($"<color=#ff6699>隨機值：{ Random.value }</color>");

            print($"<color=#ff9944>滑鼠能見度： { Cursor.visible }</color>");

            // 2. 設定靜態屬性 Set
            // 語法：
            // 類別名稱.靜態屬性名稱 指定 值；
            Cursor.visible = false;             // 隱藏滑鼠

            Screen.fullScreen = true;           // 設定為全螢幕 (執行檔有作用)

            // Random.value = 0.5f;             // Read Only 唯讀屬性不能設定

            // 靜態方法 Static Methods
            // 3. 使用靜態方法
            // 語法：
            // 類別名稱.靜態方法名稱(對應的引數)；
            print($"<color=#3399ff>隨機攻擊 100.5 ~ 150.9：{ Random.Range(100.5f, 150.9f) }</color>");

            float random = Random.Range(10.9f, 20.5f);
            print($"<color=#3366ff>隨機攻擊 10.9 ~ 20.5：{ random }</color>");
        }

        private void Start()
        {
            print($"<color=#6699ff>所有攝影機數量：{ Camera.allCamerasCount }</color>");
            print($"<color=#6699ff>圓周率：{ Mathf.PI }</color>");

            Physics.gravity = new Vector3(0, 10, 0);
            Time.timeScale = 5;
            Screen.brightness = 0.3f;

            print($"<color=#6699ff>9.99 無條件捨去：{ Mathf.Floor(9.99f) }</color>");

            Application.OpenURL("https://unity.com/");
        }

        private void Update()
        {
            // 靜態方法 Static Methods
            // 3. 使用靜態方法
            // 語法：
            // 類別名稱.靜態方法名稱(對應的引數)；
            float h = Input.GetAxis("Horizontal");
            print($"<color=#66ff33>水平軸向值：{ h }</color>");

            // print($"<color=#6699ff>經過時間：{ Time.time }</color>");

            bool space = Input.GetKeyDown(KeyCode.Space);
            print($"<color=#6699ff>是否按下空白鍵： {space} </color>");
        }
    }
}
