using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] private GameController gameController;

    /// <summary>
    /// 接触したオブジェクトがPlayerなら、プレイヤー接触フラグをtrueにする
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Goal !!!");
        if (collider.gameObject.CompareTag("Player"))
        {
            TouchedPlayer(gameController);
        }
    }

    private void TouchedPlayer(GameController gameControler)
    {
        gameControler.GameClear();
    }
}
