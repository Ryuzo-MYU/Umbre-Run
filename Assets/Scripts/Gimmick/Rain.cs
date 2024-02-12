using UnityEngine;

public class Rain : Gimmick
{
    [SerializeField] GameObject chaser;
    [SerializeField] Vector3 offset;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    protected override void GimmickFailed(GameObject gameobject)
    {
        Debug.Log("Rain起動");
        BackCollisionedTarget();

        // SE再生
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioClip);
    }

    private void BackCollisionedTarget()
    {
        // Playerの現在の座標
        Vector3 playerCurrentPos = player.transform.position;
        // Chaserの現在の座標
        Vector3 chaserCurrentPos = chaser.transform.position;
        // Rainによって戻される予定のPlayerの座標
        Vector3 playerNextPos = playerCurrentPos + offset;

        // 変更後のPlayerのx座標 ≦ Chaserの現在位置 の場合
        if (playerNextPos.x <= chaserCurrentPos.x)
        {
            Debug.Log("PlayerをChaserと同じ位置に");
            // Playerの位置をChaserと同じ位置に
            player.transform.position = chaserCurrentPos;
        }
        // Chaserの現在位置 < 変更後のPlayerのx座標 の場合
        else
        {
            Debug.Log("Playerを少し前の位置に");
            // Player の位置をoffset分戻す
            player.transform.position += offset;
        }
    }
}
