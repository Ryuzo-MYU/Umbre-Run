using UnityEngine;

public class Rain : Gimmick
{
    [SerializeField] Vector3 offset;
    private bool rainActivated;
    public override void GimmickFailed()
    {
        if (!rainActivated)
        {
            Transform playerTransform = player.GetComponent<Transform>();
            playerTransform.position += offset;
            rainActivated = true;
        }
    }
}
