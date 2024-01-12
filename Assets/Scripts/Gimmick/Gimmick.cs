using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour
{
    public bool isCollisionedPlayer;
    public bool GimmickActivated = false;

    // ギミックごとの正しい方向・開閉状態
    public string direction;
    public bool isOpen;

    // プレイヤー関連の情報
    public GameObject player;
    public Umbrella umbrella;

    //public static event Action<Gimmick> OnCleared;

    private void Start()
    {
        GimmickActivated = false;
    }

    private void Update()
    {
        // もしプレイヤーと接触していて、かつ、傘のコマンドが正しいものなら、ギミッククリア時の処理を実行する
        if (isCollisionedPlayer &&
            IsMatchingUmbrella(umbrella.direction, umbrella.isOpen))
        {
            GimmickCleared();
        }
    }

    /// <summary>
    /// 衝突時の処理
    /// PlayerとUmbrellaのスクリプトを取得する
    /// isCollisionedPlayerをtrueにする
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GimmickActivated)
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
            GimmickActivated = true;
        }
    }


    /// <summary>
    /// ギミッククリア時の処理
    /// 各種ギミックでこの関数をオーバーライドする
    /// </summary>
    public virtual void GimmickCleared() { }

    /// <summary>
    /// 傘の向き・開閉状態が、自分の正解コマンドと合っているかを判定する
    /// </summary>
    /// <param name="direction"> 傘の方向 </param>
    /// <param name="isOpen"> 傘の開閉状態 </param>
    /// <returns>
    /// 傘のコマンドが自分の正解コマンドと一致 → true
    /// 一致していない                         → false
    /// </returns>
    private bool IsMatchingUmbrella(string direction, bool isOpen)
    {
        return direction == this.direction && isOpen == this.isOpen;
    }
}
