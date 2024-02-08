using UnityEngine;

public class Player : Person
{
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject col = collision.gameObject;
        if (col.CompareTag("Gimmick"))
        {
            EncountedGimmick();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        ClearedGimmick();    
    }

    // EncountedGimmickを操作するメソッド
    // Gimmick側で使用する
    public void ClearedGimmick()
    {
        canRun = true;
    }
    public void EncountedGimmick()
    {
        canRun = false;
    }
}
