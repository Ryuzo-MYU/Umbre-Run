using UnityEngine;

public class Rain : Gimmick
{
    [SerializeField] Vector3 offset;
    protected override void GimmickFailed()
    {
        Transform playerTransform = player.GetComponent<Transform>();
        playerTransform.position += offset;
        playerScript.EncountedGimmickFalse();
    }
}
