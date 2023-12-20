using UnityEngine;

public class CamChasePlayer : MonoBehaviour
{
    public Transform player;  // �v���C���[��Transform���i�[����ϐ�
    public Vector3 offset;    // �J�����ƃv���C���[�̑��Έʒu�I�t�Z�b�g

    void Update()
    {
        if (player != null)
        {
            // �v���C���[�̈ʒu�ɒǏ]
           ChasePlayer(player, offset);
        }
    }

    /// <summary>
    /// �Ǐ]�������I�u�W�F�N�g�ɒǏ]����
    /// </summary>
    /// <param name="t">�Ǐ]������</param>
    /// <param name="offset"></param>
    void ChasePlayer(Transform t, Vector3 offset)
    {
            transform.position = t.position + offset;
    }
}
