using UnityEngine;

namespace KID
{
    /// <summary>
    /// 持續三秒沒有打到怪物就回收
    /// 1. 將圖層改為「回收彈珠」
    /// 2. 往回推
    /// </summary>
    public class Marble : MonoBehaviour
    {
        [SerializeField, Header("回收時間"), Range(0, 10)]
        private float recycleTime = 3;

        private Rigidbody rig;
        private float timer;

        private void Awake()
        {
            rig = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            Recycle();
        }

        private void OnCollisionEnter(Collision collision)
        {
            // 如果碰到怪物，就重數三秒
            if (collision.gameObject.name.Contains("怪物"))
            {
                timer = 0;
            }
        }

        /// <summary>
        /// 回收
        /// </summary>
        private void Recycle()
        {
            // 如果 計時器 小於 回收時間
            if (timer < recycleTime)
            {
                // 累加時間
                timer += Time.deltaTime;
                // print($"<color=#6699ff>回收時間：{timer}</color>");
            }
            // 否則 時間達到回收時間 就改圖層 並往回推
            else
            {
                timer = 0;
                gameObject.layer = 8;
                rig.AddForce(0, 0, -1500);
            }
        }
    }
}
