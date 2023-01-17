using UnityEngine;
using UnityEngine.Video;

namespace KID
{
    /// <summary>
    /// 學習 Unity 常見的資料類型
    /// </summary>
    public class LearnDataType : MonoBehaviour
    {
        // 儲存資料，例如：音樂、影片、圖片、按鍵、材質...
        [Header("儲存資料")]
        public AudioClip sound;     // 可存放音效音樂 mp3, ogg, avi
        public VideoClip video;     // 存放影片 mp4, ogg, wmv
        public Sprite picture;      // 可存放圖片 png, jpg, psd
        public Material material;   // 可存放材質球
        public KeyCode key;         // 可存放滑鼠、鍵盤、搖桿

        // enum 列舉 (下拉選單)
        public KeyCode keyJump = KeyCode.Space;
        public KeyCode keyFire = KeyCode.Mouse0;    // 滑鼠左鍵

        [Header("顏色與座標")]
        public Color color;                                     // 預設顏色為黑色透明
        public Color red = Color.red;                           // 內建紅
        public Color yellow = Color.yellow;                     // 內建黃
        public Color colorCustom1 = new Color(1, 0.5f, 0);      // 自訂顏色 (R,G,B)
        public Color colorCustom2 = new Color(0, 0.5f, 1, 0.5f);// 自訂顏色 (R,G,B,A)

        // 二維、三維、四維向量
        public Vector2 v2;
        public Vector3 v3;
        public Vector4 v4;

        public Vector3 v3Zero = Vector3.zero;   // 0 0 0
        public Vector3 v3One = Vector3.one;     // 1 1 1
        public Vector3 v3R = Vector3.right;     // 1 0 0 - X 右邊 ※ 
        public Vector3 v3U = Vector3.up;        // 0 1 0 - Y 上方 ※
        public Vector3 v3F = Vector3.forward;   // 0 0 1 - Z 前方 ※

        public Vector3 v3Custom = new Vector3(0.5f, 99.9f, -3.35f);

        [Header("物件與元件")]
        // 物件：場景上的遊戲物件、專案內的預製物
        public GameObject objectCat;
        public GameObject prefabMarble;
        // 元件：物件屬性面板上可折疊的
        public Transform transformSlime;
        public Animator animatorSlime;
        public Camera cameraMain;
        public Light lightMain;
    }
}
