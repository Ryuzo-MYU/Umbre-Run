using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFlow : Gimmick
{
    [SerializeField] private float airPower;
    [SerializeField] private float time;

    /// <summary>
    /// AirFlow�N���A���̏���
    /// Player����ɔ�΂�
    /// time�̃t���[�����������s��
    /// </summary>
    public override void GimmickCleared()
    {
        // �M�~�b�N�����t���O��false��
        Player pl = player.GetComponent<Player>();

        if (time > 0)
        {
            pl.EncountedGimmick = false;
            // Player����ɔ�΂�
            Vector2 airVector = Vector2.up * airPower;
            player.GetComponent<Rigidbody2D>().AddForce(airVector, ForceMode2D.Impulse);
            GimmickActivated = true;

            time--;
        }
        // �w�肵�����ԏ������s��ꂽ��AGimmick�N���ς݃t���O���I���ɂ���
        else
        {
            GimmickActivated = false;
        }
    }
}
