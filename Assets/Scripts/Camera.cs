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
    ///    �����ɓn�����I�u�W�F�N�g�Ɉ��̋�����ۂ��ĒǏ]����
    /// </summary>
    /// <param name="t">�Ǐ]�������I�u�W�F�N�g��Transform</param>
    /// <param name="offset">�I�u�W�F�N�g�Ƃ̋���</param>
    void ChasePlayer(Transform t, Vector3 offset)
    {
        transform.position = t.position + offset;
    }
}
