using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirFlow : Gimmick
{
    [SerializeField] private float airPower;

    public override void GimmickCleared()
    {
        player.GetComponent<Player>().EncountedGimmick = false;

        Rigidbody2D plrb = player.GetComponent<Rigidbody2D>();
        Vector2 airVector = Vector2.up * airPower;
        plrb.AddForce(airVector, ForceMode2D.Impulse);
    }
}
