using UnityEngine;
using System.Collections;       // 條件 1

namespace KID
{
    /// <summary>
    /// 學習協同程序 (協同或協程)
    /// </summary>
    public class LearnCoroutine : MonoBehaviour
    {
        // 作用：讓程式的時間停止
        // 條件：
        // 1. 引用系統集合命名空間
        // 2. 定義一個傳回 IEnumerator 的方法
        // 3. 方法內使用 yield return 時間
        // 4. 使用 Start Coroutine 啟動

        // 條件 2
        private IEnumerator Test()
        {
            print("<color=#ff6699>第一行</color>");

            // 條件 3
            yield return new WaitForSeconds(2);

            print("<color=#66ff99>第二行</color>");
        }

        private void Awake()
        {
            StartCoroutine(Test());     // 條件 4

            StartCoroutine(Test2());
        }

        private IEnumerator Test2()
        {
            print("測試 1");

            yield return new WaitForSeconds(3);

            print("測試 2");

            yield return new WaitForSeconds(2);

            print("測試 3");
        }
    }
}
