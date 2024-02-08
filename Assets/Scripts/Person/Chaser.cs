using UnityEngine;

public class Chaser : Person
{
    [SerializeField] private GameController gameController;

    /// <summary>
    /// 接触したオブジェクトがPlayerなら、プレイヤー接触フラグをtrueにする
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CaughtPlayer(gameController);
        }
    }

    private void CaughtPlayer(GameController gameController)
    {
        gameController.GameOver();
    }
}
