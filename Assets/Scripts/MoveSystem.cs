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
        [SerializeField, Header("對玩家造成傷害的位置")]
        private float endPosition = 1;
        [SerializeField, Header("敵人資料")]
        private DataEnemy data;

        private DamagePlayer damagePlayer;

        private void Awake()
        {
            damagePlayer = FindObjectOfType<DamagePlayer>();
        }

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

            AttackPlayer();
        }

        private void AttackPlayer()
        {
            // 如果 Z 座標無條件去除小數點 <= 對玩家造成傷害的位置
            if (Mathf.Floor(transform.position.z) <= endPosition)
            {
                // 如果不是彈珠才會對玩家造成傷害
                if (!gameObject.name.Contains("彈珠"))
                {
                    // 玩家傷害.造成傷害(資料的攻擊力)
                    damagePlayer.GetDamage(data.attack);
                }

                // 刪除物件
                Destroy(gameObject);
            }
        }
    }
}
