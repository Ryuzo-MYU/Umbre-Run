using UnityEngine;

public class Bridge : Gimmick
{
    public override void GimmickCleared()
    {
        GameObject bridgeChild = gameObject.transform.GetChild(0).gameObject;
        bridgeChild.SetActive(true);
    }
}
