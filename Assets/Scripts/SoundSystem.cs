using UnityEngine;

namespace KID
{
    /// <summary>
    /// 音效系統
    /// </summary>
    public class SoundSystem : MonoBehaviour
    {
        #region 欄位
        // 靜態欄位 名字為 實例(實體物件)
        public static SoundSystem instance;

        [Header("音效")]
        public AudioClip soundFireMarble;
        public AudioClip soundEnemyHurt;
        public AudioClip soundEnemyDead;
        public AudioClip soundEnemyMove;
        public AudioClip soundEatCoin;
        public AudioClip soundPlayerHurt;
        public AudioClip soundPlayerDead;
        public AudioClip soundGameWin;
        public AudioClip soundGameLose;
        public AudioClip soundButtonClick; 
        #endregion

        private AudioSource aud;

        private void Awake()
        {
            // 將 Unity 此物件儲存到靜態欄位內
            instance = this;

            // 取得音效來源元件
            aud = GetComponent<AudioSource>();
        }

        // 播放音效方法：隨機音量並可指定音效片段
        public void PlaySound(float min, float max, AudioClip sound)
        {
            // 取得隨機音量
            float randomVolume = Random.Range(min, max);
            // 音效來源.播放一次音效
            aud.PlayOneShot(sound, randomVolume);
        }
    }
}
