using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFlow : Gimmick
{
    [SerializeField] private float airPower;
    [SerializeField] private float time;

    /// <summary>
    /// AirFlowクリア時の処理
    /// Playerを上に飛ばす
    /// timeのフレーム分処理を行う
    /// </summary>
    public override void GimmickCleared()
    {
        // ギミック遭遇フラグをfalseに
        Player pl = player.GetComponent<Player>();

        if (time > 0)
        {
            pl.EncountedGimmick = false;
            // Playerを上に飛ばす
            Vector2 airVector = Vector2.up * airPower;
            player.GetComponent<Rigidbody2D>().AddForce(airVector, ForceMode2D.Impulse);
            GimmickActivated = true;

            time--;
        }
        // 指定した時間処理が行われたら、Gimmick起動済みフラグをオンにする
        else
        {
            GimmickActivated = false;
        }
    }
}
