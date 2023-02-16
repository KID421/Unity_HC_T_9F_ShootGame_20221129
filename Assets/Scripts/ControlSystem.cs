using UnityEngine;

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
            SpawnMarble();
        }

        private void Update()
        {
            
        }
        #endregion

        #region 方法
        /// <summary>
        /// 生成彈珠
        /// </summary>
        private void SpawnMarble()
        {
            for (int i = 0; i < countMarbleTotal; i++)
            {
                // Object.Instantiate(prefabMarble);       // 不簡寫

                // 生成(物件，座標，角度)；
                // 生成(彈珠預製物，生成位置的座標，生成位置的角度)；
                Instantiate(prefabMarble, pointSpawn.position, pointSpawn.rotation);
            }
        }
        #endregion
    }
}
