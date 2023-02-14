using UnityEngine;

namespace KID
{
    /// <summary>
    /// �ǲ߫D�R�A API
    /// ���C���������骫��A�ҥH�ϥγo���� API �e�|���ݭn���@�Ӫ���
    /// </summary>
    public class LearnAPI : MonoBehaviour
    {
        public Transform unityChan;     // ��������M�w�N�O API ���O

        public Camera mainCamera;

        public Transform rabbit;

        private void Awake()
        {
            // �B�J 1. ���T�w�����W�����骫��s�b
            // �B�J 2. �w�q�Ӫ������ (�M�w�������)
            // �B�J 3. �s���D�R�A�ݩʩΤ�k

            // �D�R�A�ݩ� Properties
            // 1. ���o�D�R�A�ݩ�
            // �y�k�G
            // ���W��.�D�R�A�ݩ�
            print($"<color=#ff6633>Unity �檺�y�СG{ unityChan.position }</color>");

            print($"<color=#ff6633>��v�����`�סG { mainCamera.depth }</color>");

            // 2. �]�w�D�R�A�ݩ�
            // �y�k�G
            // ���W��.�D�R�A�ݩ� ���w �ȡF
            rabbit.localScale = Vector3.one * 10;
        }
    }
}
