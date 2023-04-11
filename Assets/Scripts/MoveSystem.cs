using UnityEngine;
using System.Collections;

namespace KID
{
    /// <summary>
    /// 移動系統
    /// </summary>
    public class MoveSystem : MonoBehaviour
    {
        [SerializeField, Header("往前移動的單位"), Range(0, 5)]
        private float moveDistance = 2;

        /// <summary>
        /// 開始移動
        /// </summary>
        public void StartMove()
        {
            StartCoroutine(Move());
        }

        /// <summary>
        /// 移動
        /// </summary>
        private IEnumerator Move()
        {
            // 每一次要移動的單位
            float countMove = 10;                                       // 移動次數
            float unitPerMove = moveDistance / countMove;               // 計算每次移動單位

            for (int i = 0; i < countMove; i++)                         // 迴圈執行移動
            {
                transform.position -= new Vector3(0, 0, unitPerMove);   // Z 軸減掉移動單位
                yield return new WaitForSeconds(0.03f);                 // 等待
            }
        }
    }
}
