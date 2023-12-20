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
    /// 追従したいオブジェクトに追従する
    /// </summary>
    /// <param name="t">追従したい</param>
    /// <param name="offset"></param>
    void ChasePlayer(Transform t, Vector3 offset)
    {
            transform.position = t.position + offset;
    }
}
