using UnityEngine;

public class Bridge : Gimmick
{
    protected override void GimmickCleared()
    {
        GameObject bridgeChild = gameObject.transform.GetChild(0).gameObject;
        bridgeChild.SetActive(true);
    }
}
