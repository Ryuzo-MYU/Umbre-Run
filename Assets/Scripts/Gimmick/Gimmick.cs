using UnityEngine;

public class Gimmick : MonoBehaviour
{
    private bool gimmickCollisioned; //衝突フラグ
    public bool isWorkAgain; // 複数回起動するか？
    private bool isWorked; // 起動済みフラグ

    // ギミックごとの正しい方向・開閉状態
    public string direction;
    public bool isOpen;

    // プレイヤー関連の情報
    public GameObject player;
    public Player pl;
    public Umbrella umbrella;

    //public static event Action<Gimmick> OnCleared;

    private void Start()
    {
        gimmickCollisioned = false;
    }

    private void Update()
    {
        // プレイヤーと接触していて、まだ起動していないならコマンド判定を行う。
        // コマンドに応じて、ギミックごとにクリア時・失敗時の処理を行う
        if (gimmickCollisioned && !isWorked)
        {
            if (IsMatchingUmbrella(umbrella.direction, umbrella.isOpen))
            {
                GimmickCleared();
                this.gameObject.GetComponent<Collider2D>().enabled = false;
            }
            else
            {
                GimmickFailed();
            }
            isWorked = true;
            pl.EncountedGimmickFalse();
        }
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
            pl = player.GetComponent<Player>();

            // Umbrellaスクリプトの取得
            var _umb = collision.gameObject.transform.GetChild(0);
            umbrella = _umb.GetComponent<Umbrella>();

            gimmickCollisioned = true;
        }
    }


    /// <summary>
    /// ギミッククリア時の処理
    /// 各種ギミックでこの関数をオーバーライドする
    /// </summary>
    public virtual void GimmickCleared() { }

    /// <summary>
    /// ギミック失敗時の処理
    /// 各種ギミックでこの関数をオーバーライドする
    /// </summary>
    public virtual void GimmickFailed() { }

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
