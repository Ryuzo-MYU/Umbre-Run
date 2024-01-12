using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : Person
{
    public bool isTouchedPlayer; // �v���C���[�ڐG�t���O

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        isTouchedPlayer = false;
    }

    /// <summary>
    /// �ڐG�����I�u�W�F�N�g��Player�Ȃ�A�v���C���[�ڐG�t���O��true�ɂ���
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchedPlayer = true;
        }
    }

    private void FixedUpdate()
    {
        if (!isTouchedPlayer) { Run(rb, speed); }
        else { Stop(rb); };
    }
}
