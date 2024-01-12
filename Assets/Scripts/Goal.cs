using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isTouchedPlayer; // �v���C���[�ڐG�t���O

    void Start()
    {
        isTouchedPlayer = false;
    }

    /// <summary>
    /// �ڐG�����I�u�W�F�N�g��Player�Ȃ�A�v���C���[�ڐG�t���O��true�ɂ���
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Goal !!!");
        if (collider.gameObject.CompareTag("Player"))
        {
            isTouchedPlayer = true;
        }
    }
}
