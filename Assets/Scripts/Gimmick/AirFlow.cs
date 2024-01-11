using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFlow : Gimmick
{
    [SerializeField] private float airPower;

    /// <summary>
    ///     AirFlow�N���A��
    ///     Player����ɔ�΂�
    /// </summary>
    public override void GimmickCleared()
    {
        // �M�~�b�N�����t���O��false��
        Player pl = player.GetComponent<Player>();
        pl.EncountedGimmick = false;

        // Player����ɔ�΂�
        Vector2 airVector = Vector2.up * airPower;
        player.GetComponent<Rigidbody2D>().AddForce(airVector, ForceMode2D.Impulse);
        GimmickActivated = true;
    }
}
