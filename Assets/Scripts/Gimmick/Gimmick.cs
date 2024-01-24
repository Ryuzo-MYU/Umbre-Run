using UnityEngine;

public class Gimmick : MonoBehaviour
{
    public bool isWorkAgain; // 複数回起動するか？
    private bool isWorked; // 起動済みフラグ

    // ギミックごとの正しい方向・開閉状態
    public string direction;
    public bool isOpen;

    // プレイヤー関連の情報
    public GameObject player;
    public Player playerScript;
    public Umbrella umbrella;

    private void Start()
    {

    }

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
            Debug.Log("collisioned!");

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
        Debug.Log("Colliderオブジェクトが内部にいます");

        if (IsMatchingUmbrella(umbrella.GetDirection(), umbrella.GetIsOpen()))
        {
            GimmickCleared();
            Debug.Log("ギミッククリア");
            playerScript.EncountedGimmickFalse();
        }
        else
        {
            GimmickFailed();
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
    private bool IsMatchingUmbrella(string direction, bool isOpen)
    {
        return direction == this.direction && isOpen == this.isOpen;
    }
}
