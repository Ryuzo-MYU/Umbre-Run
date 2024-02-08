using UnityEngine;

public class Bridge : Gimmick
{
    protected override void GimmickCleared()
    {
        Debug.Log("Bridge起動");
        GameObject bridgeChild = gameObject.transform.GetChild(0).gameObject;
        bridgeChild.SetActive(true);
    }
}
