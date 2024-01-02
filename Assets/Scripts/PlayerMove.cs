using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// Rigidbody2D : Run関数に使用
    /// speed : Runの速度係数
    /// isRunning : trueならRunを実行。encountedGimmickがtrueならisRunningはfalseになり、Runをやめる
    /// encountedGimmick : Gimmickに遭遇したらtrue
    /// </summary>

    [SerializeField] private Rigidbody2D rb; //Run関数に使用
    [SerializeField] private float speed; //Runの速度係数
    [SerializeField] private bool encountedGimmick; //Gimmickに遭遇したかどうかのフラグ。falseならRunする

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
    /// <param name="rb">GameObjectのRigidbodyコンポーネント</param>
    /// <param name="speed">走るスピード</param>
    private void Run(Rigidbody2D rb, float speed)
    {
        rb.velocity = transform.right * speed;
    }

    /// <summary>
    /// Gimmickに衝突したらギミック遭遇フラグをtrueにして、走るのを止める
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gimmick")
        {
            encountedGimmick = true;
            Debug.Log("Player met Gimmick");
        }
    }

    // GimmickがDestroyされたときに呼ばれるメソッド
    // ギミック遭遇フラフをfalseにする
    private void HandleGimmickDestroyed(Gimmick destroyedGimmick)
    {
        encountedGimmick = false;
    }
}
