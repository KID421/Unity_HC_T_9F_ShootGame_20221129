using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  // 引用 場景管理 命名空間
using System.Collections;

namespace KID
{
    /// <summary>
    /// 遊戲管理：遊戲勝利、失敗、重新、離開遊戲
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region 資料
        private CanvasGroup groupFinal;
        private Button btnReplay;
        private Button btnQuit;
        private TextMeshProUGUI textFinalTitle; 
        #endregion

        private void Awake()
        {
            groupFinal = GameObject.Find("結束畫面底圖").GetComponent<CanvasGroup>();
            btnReplay = GameObject.Find("按鈕重新遊戲").GetComponent<Button>();
            btnQuit = GameObject.Find("按鈕離開遊戲").GetComponent<Button>();
            textFinalTitle = GameObject.Find("文字結束標題").GetComponent<TextMeshProUGUI>();

            // 點擊重新遊戲按鈕後執行 Replay 方法
            btnReplay.onClick.AddListener(Replay);
            btnQuit.onClick.AddListener(Quit);
        }

        /// <summary>
        /// 開始顯示結束畫面並更新結束標題
        /// </summary>
        /// <param name="title">要更新的標題字串</param>
        public void StartShowFinalAndUpdateTitle(string title)
        {
            // 搬移程式，複選程式後按住 Alt + 上下
            // 啟動協同程序
            StartCoroutine(ShowFinal());
            textFinalTitle.text = title;
        }

        /// <summary>
        /// 顯示結束畫面
        /// </summary>
        private IEnumerator ShowFinal()
        {
            // 群組元件每次遞增 0.1 透明度，執行十次
            for (int i = 0; i < 10; i++)
            {
                groupFinal.alpha += 0.1f;
                yield return new WaitForSeconds(0.05f);     // 每次等 0.05 秒
            }

            // 群組元件勾選互動與遮擋 讓玩家可以選取
            groupFinal.interactable = true;
            groupFinal.blocksRaycasts = true;
        }

        /// <summary>
        /// 重新遊戲
        /// </summary>
        private void Replay()
        {
            // 重新載入目前場景
            string nameCurrent = SceneManager.GetActiveScene().name;    // 取得啟動中場景的名稱
            SceneManager.LoadScene(nameCurrent);                        // 載入指定場景名稱的場景
        }

        /// <summary>
        /// 離開遊戲
        /// </summary>
        private void Quit()
        {
            // 應用程式.離開 - Unity 與 Web 不執行
            Application.Quit();
        }
    }
}
