using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : Gimmick
{

    public override void GimmickCleared()
    {
        GameObject _bridgeChild = gameObject.transform.GetChild(0).gameObject;
        _bridgeChild.SetActive(true);

        // M~bN๖tO๐falseษ
        Player pl = player.GetComponent<Player>();
        pl.EncountedGimmick = false;
    }
}
