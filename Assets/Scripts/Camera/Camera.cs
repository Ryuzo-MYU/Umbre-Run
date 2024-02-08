using UnityEngine;

public class CamChasePlayer : MonoBehaviour
{
    public Transform player;  // プレイヤーのTransformを格納する変数
    public Vector3 offset;    // カメラとプレイヤーの相対位置オフセット

    void Update()
    {
        if (player != null)
        {
            // プレイヤーの位置に追従
            ChasePlayer(player, offset);
        }
    }

    /// <summary>
    ///    引数に渡したオブジェクトに一定の距離を保って追従する
    /// </summary>
    /// <param name="t">追従したいオブジェクトのTransform</param>
    /// <param name="offset">オブジェクトとの距離</param>
    void ChasePlayer(Transform t, Vector3 offset)
    {
        transform.position = t.position + offset;
    }
}
