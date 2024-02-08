using UnityEngine;

public class Rain : Gimmick
{
    [SerializeField] GameObject chaser;
    [SerializeField] Vector3 offset;
    protected override void GimmickFailed()
    {
        Debug.Log("Rain起動");
        BackCollisionedTarget();
    }

    private void BackCollisionedTarget()
    {
        // Playerの現在の座標
        Vector3 playerCurrentHorizontalPos = player.transform.position;
        // Chaserの現在の座標
        Vector3 chaserCurrentHorizontalPos = chaser.transform.position;
        // Rainによって戻される予定のPlayerの座標
        Vector3 playerNextHorizontalPos = playerCurrentHorizontalPos + offset;

        // 変更後のPlayerのx座標 ≦ Chaserの現在位置 の場合
        if (playerNextHorizontalPos.x <= chaserCurrentHorizontalPos.x)
        {
            // Playerの位置をChaserと同じ位置に
            player.transform.position = chaserCurrentHorizontalPos;
        }
        // Chaserの現在位置 ≦ 変更後のPlayerのx座標 の場合
        else
        {
            // Player の位置をoffset分戻す
            player.transform.position += offset;
        }
    }
}
