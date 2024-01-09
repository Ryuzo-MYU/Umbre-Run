using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb; //Run関数に使用
    [SerializeField] private float speed; //Runの速度係数
    [SerializeField] private bool encountedGimmick; //Gimmickに遭遇したかどうかのフラグ。falseならRunする
    public bool EncountedGimmick
    {
        // encountedGimmickのプロパティ
        get { return encountedGimmick; }
        set { encountedGimmick = value; }
    }



    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!encountedGimmick) { Run(rb, speed); }
        else { Stop(rb); }
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
        rb.AddForce(Vector2.right * speed, ForceMode2D.Force);
    }

    private void Stop(Rigidbody2D rb)
    {
        rb.velocity = Vector2.zero;
    }
}
