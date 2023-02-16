using UnityEngine;

namespace KID
{
    /// <summary>
    /// 學習非靜態 API
    /// 指遊戲內的實體物件，所以使用這類的 API 前會先需要有一個物件
    /// </summary>
    public class LearnAPI : MonoBehaviour
    {
        #region 欄位
        public Transform unityChan;     // 資料類型決定就是 API 類別

        public Camera mainCamera;

        public Transform rabbit;

        public Light mainLight;

        public Transform girl;
        #endregion

        public BoxCollider cube;
        public AudioSource testAudio;
        public Canvas testCanvas;

        public Rigidbody rigSphere;
        public Transform testCube, testSphere;
        public Transform testCapsule;

        private void Awake()
        {
            // 步驟 1. 先確定場景上有實體物件存在
            // 步驟 2. 定義該物件的欄位 (決定資料類型)
            // 步驟 3. 存取非靜態屬性或方法

            // 非靜態屬性 Properties
            // 1. 取得非靜態屬性
            // 語法：
            // 欄位名稱.非靜態屬性
            print($"<color=#ff6633>Unity 醬的座標：{ unityChan.position }</color>");

            print($"<color=#ff6633>攝影機的深度： { mainCamera.depth }</color>");

            // 2. 設定非靜態屬性
            // 語法：
            // 欄位名稱.非靜態屬性 指定 值；
            rabbit.localScale = Vector3.one * 10;

            mainLight.color = new Color(1, 0.3f, 0.3f);
        }

        private void Start()
        {
            print($"<color=#66ff99>{ cube.size }</color>");
            print($"<color=#66ff99>{ testAudio.volume }</color>");
            print($"<color=#66ff99>{ testCanvas.renderMode }</color>");

            cube.center = new Vector3(1, 3, 1);
            testAudio.volume = 0.5f;
            testCanvas.renderMode = RenderMode.WorldSpace;

            rigSphere.AddForce(0, 1500, 0);     // 球體往上推
        }

        private void Update()
        {
            // 非靜態方法 Methods
            // 3. 使用非靜態方法
            // 語法：
            // 欄位名稱.非靜態方法(對應的引數)；
            girl.Rotate(0, 30, 0);

            testCube.LookAt(testSphere);        // 立方體 面向 球體

            testCapsule.Translate(0, 0, 3);     // 膠囊 往 Z 移動
        }
    }
}
