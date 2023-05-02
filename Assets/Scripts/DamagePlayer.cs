using UnityEngine;

namespace KID
{
    /// <summary>
    /// 玩家傷害系統
    /// </summary>
    public class DamagePlayer : DamageSystemBasic
    {
        private GameManager gameManager;
        private ControlSystem controlSystem;

        protected override void Awake()
        {
            base.Awake();

            gameManager = FindObjectOfType<GameManager>();
            controlSystem = FindObjectOfType<ControlSystem>();
        }

        public override void GetDamage(float damage)
        {
            base.GetDamage(damage);

            // 先取得要播放的聲音再播放
            AudioClip sound = SoundSystem.instance.soundPlayerHurt;
            SoundSystem.instance.PlaySound(0.7f, 1.2f, sound);
        }

        protected override void Dead()
        {
            base.Dead();

            // 控制器.啟動 = 否
            controlSystem.enabled = false;
            gameManager.StartShowFinalAndUpdateTitle("挑戰失敗...");

            // 先取得要播放的聲音再播放
            AudioClip sound = SoundSystem.instance.soundPlayerDead;
            SoundSystem.instance.PlaySound(0.7f, 1.2f, sound);

            // 先取得要播放的聲音再播放
            AudioClip soundLose = SoundSystem.instance.soundGameLose;
            SoundSystem.instance.PlaySound(0.7f, 1.2f, soundLose);
        }
    }
}
