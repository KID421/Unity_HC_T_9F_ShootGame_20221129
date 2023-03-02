using UnityEngine;
using System.Collections;       // 條件 1

namespace KID
{
    /// <summary>
    /// 控制系統：控制玩家的角色旋轉、發射彈珠行為
    /// </summary>
    public class ControlSystem : MonoBehaviour
    {
        #region 資料
        [SerializeField, Header("旋轉速度"), Range(0, 60)]
        private float speedTurn = 10.5f;
        [SerializeField, Header("可發射彈珠數量"), Range(0, 100)]
        private int countMarbleTotal = 10;
        [SerializeField, Header("彈珠速度"), Range(0, 5000)]
        private int speedMarble = 1500;
        [SerializeField, Header("發射間隔"), Range(0, 0.5f)]
        private float intervalShoot = 0.5f;
        [SerializeField, Header("彈珠預製物")]
        private GameObject prefabMarble;
        [SerializeField, Header("生成彈珠位置")]
        private Transform pointSpawn;
        [SerializeField, Header("箭頭")]
        private GameObject objArrow;

        private string parAttack = "觸發攻擊";
        #endregion

        #region 事件
        private void Awake()
        {

        }

        private void Update()
        {
            InputManager();
        }
        #endregion

        #region 方法
        /// <summary>
        /// 生成彈珠
        /// </summary>
        // 條件 2
        private IEnumerator SpawnMarble()
        {
            for (int i = 0; i < countMarbleTotal; i++)
            {
                // Object.Instantiate(prefabMarble);       // 不簡寫

                // 生成(物件，座標，角度)；
                // 暫存彈珠 = 生成(彈珠預製物，生成位置的座標，生成位置的角度)；
                GameObject tempMarble = Instantiate(prefabMarble, pointSpawn.position, pointSpawn.rotation);

                // 取得元件<元件名稱>()
                // GetComponent<元件名稱>()

                // 暫存彈珠.取得元件<剛體>()
                tempMarble.GetComponent<Rigidbody>().AddForce(0, 0, speedMarble);

                // 條件 3
                yield return new WaitForSeconds(intervalShoot);
            }
        }

        /// <summary>
        /// 輸入管理：偵測玩家的滑鼠 (觸控)
        /// </summary>
        private void InputManager()
        {
            // 如果 按下 左鍵 顯示箭頭
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                print("<color=#66ff99>玩家按下左鍵</color>");

                objArrow.SetActive(true);                           // 顯示箭頭
            }
            // 如果 放開 左鍵 隱藏箭頭
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                print("<color=#ff6699>玩家放開左鍵</color>");

                objArrow.SetActive(false);                          // 隱藏箭頭

                // 條件 4
                StartCoroutine(SpawnMarble());                      // 生成彈珠
            }
        }
        #endregion
    }
}
