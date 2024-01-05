using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb; //Run関数に使用
    [SerializeField] private float speed; //Runの速度係数
    [SerializeField] private bool encountedGimmick; //Gimmickに遭遇したかどうかのフラグ。falseならRunする
    // プロパティ
    public bool EncountedGimmick
    {
        get { return encountedGimmick; }
        set { encountedGimmick = value; }
    }



    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        // Gimmickのイベントに購読を追加
        Gimmick.OnDestroyed += HandleGimmickDestroyed;
    }

    private void FixedUpdate()
    {
        if (!encountedGimmick) { Run(rb, speed); }
    }

    /// <summary>
    ///     プレイヤーに右向きの力を加えて、画面右側に進める
    /// </summary>
    /// <param name="rb">
    ///     GameObjectのRigidbodyコンポーネント
    /// </param>
    /// <param name="speed">
    ///     走るスピード
    /// </param>
    private void Run(Rigidbody2D rb, float speed)
    {
        rb.velocity = transform.right * speed;
    }

    /// <summary>
    ///     GimmickがDestroyされたときに呼ばれる
    ///     ギミック遭遇フラフをfalseにする
    /// </summary>
    /// <param name="destroyedGimmick"></param>
    private void HandleGimmickDestroyed(Gimmick destroyedGimmick)
    {
        Debug.Log("イベント発火");
        encountedGimmick = false;
    }
}
