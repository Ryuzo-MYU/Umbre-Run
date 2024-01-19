using UnityEngine;

public class Player : Person
{

    [SerializeField] private bool encountedGimmick; //Gimmickに遭遇したかどうかのフラグ。falseならRunする
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        encountedGimmick = false;
    }


    private void FixedUpdate()
    {
        if (!encountedGimmick) { Run(rb, speed); }
        else { Stop(rb); }
    }

    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject col = collision.gameObject;
        if (col.CompareTag("Gimmick"))
        {
            Debug.Log("Gimmickに衝突");
            EncountedGimmickTrue();
        }
    }

    // EncountedGimmickを操作するメソッド
    // Gimmick側で使用する
    private void EncountedGimmickTrue()
    {
        encountedGimmick = true;
    }
    public void EncountedGimmickFalse()
    {
        encountedGimmick = false;
    }
}
