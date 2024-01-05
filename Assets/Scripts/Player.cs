using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb; //Run�֐��Ɏg�p
    [SerializeField] private float speed; //Run�̑��x�W��
    [SerializeField] private bool encountedGimmick; //Gimmick�ɑ����������ǂ����̃t���O�Bfalse�Ȃ�Run����
    // �v���p�e�B
    public bool EncountedGimmick
    {
        get { return encountedGimmick; }
        set { encountedGimmick = value; }
    }



    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        // Gimmick�̃C�x���g�ɍw�ǂ�ǉ�
        Gimmick.OnDestroyed += HandleGimmickDestroyed;
    }

    private void FixedUpdate()
    {
        if (!encountedGimmick) { Run(rb, speed); }
    }

    /// <summary>
    ///     �v���C���[�ɉE�����̗͂������āA��ʉE���ɐi�߂�
    /// </summary>
    /// <param name="rb">
    ///     GameObject��Rigidbody�R���|�[�l���g
    /// </param>
    /// <param name="speed">
    ///     ����X�s�[�h
    /// </param>
    private void Run(Rigidbody2D rb, float speed)
    {
        rb.velocity = transform.right * speed;
    }

    /// <summary>
    ///     Gimmick��Destroy���ꂽ�Ƃ��ɌĂ΂��
    ///     �M�~�b�N�����t���t��false�ɂ���
    /// </summary>
    /// <param name="destroyedGimmick"></param>
    private void HandleGimmickDestroyed(Gimmick destroyedGimmick)
    {
        Debug.Log("�C�x���g����");
        encountedGimmick = false;
    }
}
