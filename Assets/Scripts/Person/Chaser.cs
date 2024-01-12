using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chaser : Person
{
    public bool isTouchedPlayer; // プレイヤー接触フラグ

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        isTouchedPlayer = false;
    }

    /// <summary>
    /// 接触したオブジェクトがPlayerなら、プレイヤー接触フラグをtrueにする
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isTouchedPlayer = true;
        }
    }

    private void FixedUpdate()
    {
        if (!isTouchedPlayer) { Run(rb, speed); }
        else { Stop(rb); };
    }
}
