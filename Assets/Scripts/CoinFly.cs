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
        [SerializeField, Header("延遲飛行時間"), Range(0, 5)]
        private float delayFly = 2;

        /// <summary>
        /// 金幣要前往的座標
        /// </summary>
        private Transform pointFlyTo;

        private CoinManager coinManager;

        private void Awake()
        {
            // 尋找物件(物件名稱)
            // 找到`金幣要前往的座標`的`transform 變形`元件 並儲存於`pointFlyTo`欄位
            pointFlyTo = GameObject.Find("金幣要前往的座標").transform;

            // 取得金幣管理器
            coinManager = FindObjectOfType<CoinManager>();

            // 延遲呼叫(方法名稱，延遲秒數)；
            Invoke("StartFly", delayFly);       // 延遲兩秒再呼叫 StartFly
        }

        private void Update()
        {
            Fly();
        }

        private void StartFly()
        {
            // 控制元件啟動狀態 enable
            enabled = true;
        }

        /// <summary>
        /// 金幣飛行
        /// </summary>
        private void Fly()
        {
            #region 金幣飛行
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
            #endregion

            UpdateCoinAndDestroy();
        }

        private void UpdateCoinAndDestroy()
        {
            // 如果跟左上角要前往的座標距離 < 1 就刪除並更新金幣數量
            // 距離 = 三維向量.距離(金幣座標，要前往的座標)
            float dis = Vector3.Distance(transform.position, pointFlyTo.position);
            
            // 距離 小於等於 1
            if (dis <= 1)
            {
                // 金幣管理器更新金幣
                coinManager.UpdateCoinCount();
                // 刪除此金幣物件
                Destroy(gameObject);
            }
        }
    }
}
