using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform player;  // �v���C���[��Transform���i�[����ϐ�
    public Vector3 offset;    // �J�����ƃv���C���[�̑��Έʒu�I�t�Z�b�g

    void Update()
    {
        if (player != null)
        {
            // �v���C���[�̈ʒu�ɒǏ]
            transform.position = player.position + offset;
        }
    }
}
