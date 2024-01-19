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
    protected override void GimmickCleared()
    {

        if (time > 0)
        {
            // Playerを上に飛ばす
            Vector2 airVector = Vector2.up * airPower;
            Rigidbody2D plrb = player.GetComponent<Rigidbody2D>();
            plrb.AddForce(airVector, ForceMode2D.Impulse);
            time--;
        }
    }
}
