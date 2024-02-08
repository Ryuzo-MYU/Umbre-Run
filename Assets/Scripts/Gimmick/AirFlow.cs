using UnityEngine;

public class AirFlow : Gimmick
{
    [SerializeField] private float airPower;
    [SerializeField] private float remainWorkTime;

    /// <summary>
    /// AirFlowクリア時の処理
    /// Playerを上に飛ばす
    /// timeのフレーム分処理を行う
    /// </summary>
    protected override void GimmickCleared()
    {

        if (remainWorkTime > 0)
        {
            Debug.Log("AirFlow起動");
            // Playerを上に飛ばす
            Vector2 airVector = Vector2.up * airPower;
            Rigidbody2D plrb = player.GetComponent<Rigidbody2D>();
            plrb.AddForce(airVector, ForceMode2D.Impulse);
            remainWorkTime--;
        }
    }
}
