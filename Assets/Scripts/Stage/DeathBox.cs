using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    [SerializeField] Vector3 offset;

    // 衝突時、衝突対象を指定の位置まで戻す 
    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject target = other.gameObject;
        backPreviousPos(target);
    }

    // 対象をoffsetの分だけ移動させる
    private void backPreviousPos(GameObject target)
    {
        Debug.Log("Playerを少し前の位置に");
        Transform targetTransform = target.transform;
        targetTransform.position += offset;
    }
}
