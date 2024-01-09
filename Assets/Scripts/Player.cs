using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb; //Run�֐��Ɏg�p
    [SerializeField] private float speed; //Run�̑��x�W��
    [SerializeField] private bool encountedGimmick; //Gimmick�ɑ����������ǂ����̃t���O�Bfalse�Ȃ�Run����
    public bool EncountedGimmick
    {
        // encountedGimmick�̃v���p�e�B
        get { return encountedGimmick; }
        set { encountedGimmick = value; }
    }



    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!encountedGimmick) { Run(rb, speed); }
        else { Stop(rb); }
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
        rb.AddForce(Vector2.right * speed, ForceMode2D.Force);
    }

    private void Stop(Rigidbody2D rb)
    {
        rb.velocity = Vector2.zero;
    }
}
