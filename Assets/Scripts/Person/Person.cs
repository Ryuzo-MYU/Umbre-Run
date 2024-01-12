using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public float speed; //Run�̑��x�W��
    public Rigidbody2D rb; //Run�֐��Ɏg�p

    /// <summary>
    ///     �I�u�W�F�N�g�ɉE�����̗͂������āA��ʉE���ɐi�߂�
    /// </summary>
    /// <param name="rb">
    ///     �I�u�W�F�N�g��Rigidbody�R���|�[�l���g
    /// </param>
    /// <param name="speed">
    ///     ����X�s�[�h
    /// </param>
    public void Run(Rigidbody2D rb, float speed)
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public void Stop(Rigidbody2D rb)
    {
        rb.velocity = Vector2.zero;
    }
}
