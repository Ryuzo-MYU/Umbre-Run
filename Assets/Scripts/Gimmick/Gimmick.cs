using UnityEngine;

public class Gimmick : MonoBehaviour
{
    // ギミックごとの正しい方向・開閉状態
    public string direction;
    public bool isOpen;

    // プレイヤー関連の情報
    public GameObject player;
    public Player playerScript;
    public Umbrella umbrella;

    /// <summary>
    /// 衝突時の処理
    /// PlayerとUmbrellaのスクリプトを取得する
    /// GimmickActivatedをtrueにする
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Playerスクリプトの取得
            player = collision.gameObject;
            playerScript = player.GetComponent<Player>();

            // Umbrellaスクリプトの取得
            var _umb = collision.gameObject.transform.GetChild(0);
            umbrella = _umb.GetComponent<Umbrella>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (IsMatchingUmbrella(umbrella))
            {
                GimmickCleared();
                playerScript.ClearedGimmick();
            }
            else
            {
                GimmickFailed();
            }
        }
    }

    /// <summary>
    /// ギミッククリア時の処理
    /// 各種ギミックでこの関数をオーバーライドする
    /// </summary>
    protected virtual void GimmickCleared() { }

    /// <summary>
    /// ギミック失敗時の処理
    /// 各種ギミックでこの関数をオーバーライドする
    /// </summary>
    protected virtual void GimmickFailed() { }

    /// <summary>
    /// 傘の向き・開閉状態が、自分の正解コマンドと合っているかを判定する
    /// </summary>
    /// <param name="direction"> 傘の方向 </param>
    /// <param name="isOpen"> 傘の開閉状態 </param>
    /// <returns>
    /// 傘のコマンドが自分の正解コマンドと一致 → true
    /// 一致していない                         → false
    /// </returns>
    private bool IsMatchingUmbrella(Umbrella umbrella)
    {
        string direction = umbrella.GetDirection();
        bool isOpen = umbrella.GetIsOpen();
        return direction == this.direction && isOpen == this.isOpen;
    }
}
