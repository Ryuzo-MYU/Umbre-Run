using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isTouchedPlayer; // プレイヤー接触フラグ

    void Start()
    {
        isTouchedPlayer = false;
    }

    /// <summary>
    /// 接触したオブジェクトがPlayerなら、プレイヤー接触フラグをtrueにする
    /// </summary>
    /// <param name="collider"></param>
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Goal !!!");
        if (collider.gameObject.CompareTag("Player"))
        {
            isTouchedPlayer = true;
        }
    }
}
