using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// Rigidbody2D : Run�֐��Ɏg�p
    /// speed : Run�̑��x�W��
    /// isRunning : true�Ȃ�Run�����s�BencountedGimmick��true�Ȃ�isRunning��false�ɂȂ�ARun����߂�
    /// encountedGimmick : Gimmick�ɑ���������true
    /// </summary>

    [SerializeField] private Rigidbody2D rb; //Run�֐��Ɏg�p
    [SerializeField] private float speed; //Run�̑��x�W��
    [SerializeField] private bool encountedGimmick; //Gimmick�ɑ����������ǂ����̃t���O�Bfalse�Ȃ�Run����

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    /// <param name="rb">GameObject��Rigidbody�R���|�[�l���g</param>
    /// <param name="speed">����X�s�[�h</param>
    private void Run(Rigidbody2D rb, float speed)
    {
        rb.velocity = transform.right * speed;
    }

    /// <summary>
    /// Gimmick�ɏՓ˂�����M�~�b�N�����t���O��true�ɂ��āA����̂��~�߂�
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gimmick")
        {
            encountedGimmick = true;
            Debug.Log("Player met Gimmick");
        }
    }

    // Gimmick��Destroy���ꂽ�Ƃ��ɌĂ΂�郁�\�b�h
    // �M�~�b�N�����t���t��false�ɂ���
    private void HandleGimmickDestroyed(Gimmick destroyedGimmick)
    {
        encountedGimmick = false;
    }
}
