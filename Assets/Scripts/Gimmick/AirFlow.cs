using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFlow : Gimmick
{
    [SerializeField] private float airPower;

    /// <summary>
    ///     AirFlowクリア時
    ///     Playerを上に飛ばす
    /// </summary>
    public override void GimmickCleared()
    {
        // ギミック遭遇フラグをfalseに
        Player pl = player.GetComponent<Player>();
        pl.EncountedGimmick = false;

        // Playerを上に飛ばす
        Vector2 airVector = Vector2.up * airPower;
        player.GetComponent<Rigidbody2D>().AddForce(airVector, ForceMode2D.Impulse);
        GimmickActivated = true;
    }
}
