using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rain : Gimmick
{
    [SerializeField] Vector3 offset;
    public override void GimmickFailed()
    {
        Transform playerTransform = player.GetComponent<Transform>();
        playerTransform.position += offset;

        Player pl = player.GetComponent<Player>();
        pl.EncountedGimmick = false;

        isCollisionedPlayer = false;
        GimmickActivated = false;
    }
}
