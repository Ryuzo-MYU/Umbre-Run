using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour
{
    public bool isCollisionedPlayer;

    // ギミックごとの正しい方向・開閉状態
    public string direction;
    public bool isOpen;

    // プレイヤー関連の情報
    public GameObject player;
    public Umbrella umbrella;

    public static event Action<Gimmick> OnDestroyed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("collisioned!");

            // Playerの取得
            player = collision.gameObject;
            player.GetComponent<Player>().EncountedGimmick = true;

            // Umbrellaスクリプトの取得
            var _umb = collision.gameObject.transform.GetChild(0);
            umbrella = _umb.GetComponent<Umbrella>();
            isCollisionedPlayer = true;
        }
    }

    private void Update()
    {
        // もしプレイヤーと接触していたら、
        // ギミックのコマンド判定をする
        if (isCollisionedPlayer)
        {
            if (IsMatchingUmbrella(umbrella.direction, umbrella.isOpen))
            {
                GimmickCleared();
            }
        }
    }

    /// <summary>
    ///     ギミッククリア時の処理
    ///     各種ギミックでこの関数をオーバーライドして使う
    /// </summary>
    public virtual void GimmickCleared() { }

    /// <summary>
    ///     ギミック破壊時の
    /// </summary>
    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }

    /// <summary>
    ///     傘の向き・開閉状態が、自分の正解コマンド
    ///     と合っているかを判定する
    /// </summary>
    /// <param name="direction"> 傘の方向 </param>
    /// <param name="isOpen"> 傘の開閉状態 </param>
    /// <returns></returns>
    private bool IsMatchingUmbrella(string direction, bool isOpen)
    {
        return direction == this.direction && isOpen == this.isOpen;
    }
}
