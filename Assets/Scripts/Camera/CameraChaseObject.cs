using UnityEngine;

public class CameraChaseObject : MonoBehaviour
{
    public Transform target;  // 追跡したいオブジェクトのTransformコンポーネント
    public Vector3 offset;    // カメラとtargetの相対位置オフセット

    void Update()
    {
        if (target != null)
        {
            // プレイヤーの位置に追従
            ChaseTarget(target, offset);
        }
    }

    /// <summary>
    ///    引数に渡したオブジェクトに一定の距離を保って追従する
    /// </summary>
    /// <param name="t">追従したいオブジェクトのTransform</param>
    /// <param name="offset">オブジェクトとの距離</param>
    void ChaseTarget(Transform t, Vector3 offset)
    {
        transform.position = t.position + offset;
    }
}
