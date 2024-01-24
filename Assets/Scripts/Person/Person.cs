using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : MonoBehaviour
{
    public float speed; //Runの速度係数
    public Rigidbody2D rb; //Run関数に使用

    /// <summary>
    ///     オブジェクトに右向きの力を加えて、画面右側に進める
    /// </summary>
    /// <param name="rb">
    ///     オブジェクトのRigidbodyコンポーネント
    /// </param>
    /// <param name="speed">
    ///     走るスピード
    /// </param>
    public void Run(Rigidbody2D rb, float speed)
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    public void Stop(Rigidbody2D rb)
    {
        rb.velocity = Vector2.zero;
    }
}
