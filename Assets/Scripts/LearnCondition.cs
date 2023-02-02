using UnityEngine;

namespace KID
{
    /// <summary>
    /// 學習判斷式 (條件式、選取語句)
    /// if 與 switch
    /// </summary>
    public class LearnCondition : MonoBehaviour
    {
        private void Awake()
        {
            // 1. if
            // 語法：
            // if (布林值) { 程式，當布林值為 true 才會執行 }
            // 快速完成：if + Tab * 2
            if (true)
            {
                print("<color=yellow>布林值為 true</color>");
            }

            // 布林值為 false 不會執行 {} 內的程式，綠色蚯蚓為提示不執行的程式
            if (false)
            {
                print("<color=yellow>布林值為 false</color>");
            }

        }

        public bool playerInEnd;        // 玩家有沒有走到終點

        public int score = 100;

        public int hp = 100;

        public string weapon = "鏟子";

        public enum Props
        {
            Red, Blue, Yellow
        }

        public Props props = Props.Blue;

        private void Update()
        {
            #region 判斷式 if
            // 範例：如果 玩家走到終點 就 過關 否則 就 沒有過關
            if (playerInEnd)
            {
                print("<color=green>過關</color>");
            }
            // else 大括號內的程式 在 playerInEnd 為 false 會執行
            else
            {
                print("<color=red>尚未過關</color>");
            }

            // 分數 大於 80 A
            // 分數 大於 60 B
            // 分數 大於 40 C 補考
            // 分數 大於 20 D 當掉
            // E 死當

            if (score > 80)
            {
                print("<color=#ff9966>A</color>");
            }
            // else if (布林值) { 當布林值 true 執行 }
            else if (score > 60)
            {
                print("<color=#ff9966>B</color>");
            }
            else if (score > 40)
            {
                print("<color=#ff9966>C，需要補考</color>");
            }
            else if (score > 20)
            {
                print("<color=#ff9966>D，當掉</color>");
            }
            else
            {
                print("<color=#ff9966>E，死當</color>");
            }
            #endregion

            #region 錯誤範例
            /* 錯誤的範例，只會執行 危險
                if (hp > 0)
                {
                    print("危險");
                }
                else if (hp > 40)
                {
                    print("警告");
                }
                else if (hp > 60)
                {
                    print("注意");
                }
                else if (hp > 80)
                {
                    print("安全");
                }
                */
            #endregion

            #region 判斷式練習
            if (hp >= 80)
            {
                print("安全");
            }
            else if (hp >= 60)
            {
                print("注意");
            }
            else if (hp >= 40)
            {
                print("警告");
            }
            else
            {
                print("危險");
            }
            #endregion

            #region 判斷式 switch
            // switch 語法
            // switch (要判斷的資料) 
            // {
            //      case 值:
            //          資料等於值會執行的程式；
            //          break;
            // }

            // 如果拿 鏟子 可以挖礦
            // 如果拿 斧頭 可以砍木頭
            // 如果拿 弓箭 可以發射弓箭
            switch (weapon)
            {
                case "鏟子":
                    print("可以挖礦！");
                    break;
                case "斧頭":
                    print("可以砍木頭！");
                    break;
                case "弓箭":
                    print("可以發射弓箭！");
                    break;

                // 當資料與上方的值皆不相同會執行此區域
                default:
                    print("你拿的武器不能使用..");
                    break;
            }
            #endregion

            switch (props)
            {
                case Props.Red:
                    print("補 HP");
                    break;
                case Props.Blue:
                    print("補 MP");
                    break;
                case Props.Yellow:
                    print("補體力");
                    break;
                default:
                    print("這道具無法使用");
                    break;
            }
        }
    }
}
