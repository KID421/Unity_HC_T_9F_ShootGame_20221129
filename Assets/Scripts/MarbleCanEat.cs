using UnityEngine;

namespace KID
{
    /// <summary>
    /// 可以吃的彈珠
    /// </summary>
    public class MarbleCanEat : MonoBehaviour
    {
        [SerializeField, Header("碰到後會被吃掉的物件名稱")]
        private string nameTarget = "彈珠";

        // 回合系統：通知玩家吃到了
        private TurnSystem turnSystem;

        private void Awake()
        {
            turnSystem = FindObjectOfType<TurnSystem>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.name.Contains(nameTarget))
            {
                // 回合系統.吃到彈珠數量 +1
                turnSystem.countEatMarble++;
                // 刪除此物件
                Destroy(gameObject);
            }
        }
    }
}
