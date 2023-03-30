using UnityEngine;

namespace KID
{
    /// <summary>
    /// 金幣飛行
    /// </summary>
    public class CoinFly : MonoBehaviour
    {
        [SerializeField, Header("飛行速度"), Range(0, 50)]
        private float speedFly = 3.5f;

        /// <summary>
        /// 金幣要前往的座標
        /// </summary>
        private Transform pointFlyTo;

        private void Awake()
        {
            // 尋找物件(物件名稱)
            // 找到`金幣要前往的座標`的`transform 變形`元件 並儲存於`pointFlyTo`欄位
            pointFlyTo = GameObject.Find("金幣要前往的座標").transform;
        }

        private void Update()
        {
            Fly();
        }

        /// <summary>
        /// 金幣飛行
        /// </summary>
        private void Fly()
        {
            // A 座標：金幣的座標
            // transform.position 指此物件的座標
            Vector3 current = transform.position;
            // B 座標：金幣要前往的座標
            Vector3 target = pointFlyTo.position;

            // 三維向量的往前移動(A，B，移動速度)
            // Time.deltaTime 該裝置的幀數分之一秒
            // Unity 建議在移動程式可透過他解決速度差問題
            Vector3 newPoint = Vector3.MoveTowards(current, target, speedFly * Time.deltaTime);

            // print($"<color=#ff6699>移動後的座標：{ newPoint }</color>");

            // 此物件的座標 = 新座標
            transform.position = newPoint;
        }
    }
}
