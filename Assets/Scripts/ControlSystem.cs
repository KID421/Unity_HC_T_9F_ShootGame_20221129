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
        public int countMarbleTotal = 10;
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
        [SerializeField, Header("滑鼠座標")]
        private Transform pointMouse;

        public static ControlSystem instance;

        [Header("玩家的資料")]
        public DataBasic data;

        private string parAttack = "觸發攻擊";
        private Animator ani;
        #endregion

        #region 事件
        private void Awake()
        {
            instance = this;
            ani = GetComponent<Animator>();
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
                // 播放攻擊動畫
                ani.SetTrigger(parAttack);

                // Object.Instantiate(prefabMarble);       // 不簡寫

                // 生成(物件，座標，角度)；
                // 暫存彈珠 = 生成(彈珠預製物，生成位置的座標，生成位置的角度)；
                GameObject tempMarble = Instantiate(prefabMarble, pointSpawn.position, pointSpawn.rotation);

                // 取得元件<元件名稱>()
                // GetComponent<元件名稱>()

                // 暫存彈珠.取得元件<剛體>().添加推力(X，Y，Z) - 世界座標
                // tempMarble.GetComponent<Rigidbody>().AddForce(0, 0, speedMarble);

                // 將推力改為角色區域座標
                // 右方 transform.right
                // 上方 transform.up
                // 前方 transfrom.forward
                tempMarble.GetComponent<Rigidbody>().AddForce(transform.forward * speedMarble);

                // 先取得要播放的聲音再播放
                AudioClip sound = SoundSystem.instance.soundFireMarble;
                SoundSystem.instance.PlaySound(0.7f, 1.2f, sound);

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
                // print("<color=#66ff99>玩家按下左鍵</color>");

                objArrow.SetActive(true);                           // 顯示箭頭
            }
            else if (Input.GetKey(KeyCode.Mouse0))
            {
                // print("<color=#6699ff>玩家按住左鍵</color>");

                MouseToWorld();
            }
            // 如果 放開 左鍵 隱藏箭頭
            else if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                // print("<color=#ff6699>玩家放開左鍵</color>");

                objArrow.SetActive(false);                          // 隱藏箭頭

                // 條件 4
                StartCoroutine(SpawnMarble());                      // 生成彈珠

                // 關閉控制系統
                // enabled 此元件啟動
                enabled = false;
            }
        }

        /// <summary>
        /// 2D 滑鼠座標轉為 3D 世界座標
        /// </summary>
        private void MouseToWorld()
        {
            // print($"<color=#ffff66>滑鼠座標： { Input.mousePosition } </color>");

            Vector3 posMouse = Input.mousePosition;     // 滑鼠座標

            posMouse.z = 15;

            // 攝影機.主要的.螢幕轉為世界座標(滑鼠座標)
            Vector3 posWorld = Camera.main.ScreenToWorldPoint(posMouse);

            // print($"<color=#ffff66>世界座標： { posWorld } </color>");

            pointMouse.position = posWorld;             // 滑鼠座標物件.座標 = 世界座標

            // 角色面向 滑鼠座標物件
            // 取得此腳本物件的 Transform 寫法：transform
            transform.LookAt(posWorld);

            // 鎖定角色 X 與 Z 軸
            Vector3 angle = transform.eulerAngles;      // 新角度 = 取得角色的角度
            angle.x = 0;                                // X 歸零
            angle.z = 0;                                // Z 歸零
            transform.eulerAngles = angle;              // 角色的角度 = 新角度
        }
        #endregion
    }
}
