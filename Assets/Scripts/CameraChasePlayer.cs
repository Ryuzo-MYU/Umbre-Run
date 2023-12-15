using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform player;  // プレイヤーのTransformを格納する変数
    public Vector3 offset;    // カメラとプレイヤーの相対位置オフセット

    void Update()
    {
        if (player != null)
        {
            // プレイヤーの位置に追従
            transform.position = player.position + offset;
        }
    }
}
