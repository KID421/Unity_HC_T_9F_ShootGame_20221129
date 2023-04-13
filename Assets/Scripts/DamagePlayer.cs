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

        protected override void Dead()
        {
            base.Dead();

            // 控制器.啟動 = 否
            controlSystem.enabled = false;
            gameManager.StartShowFinalAndUpdateTitle("挑戰失敗...");
        }
    }
}
