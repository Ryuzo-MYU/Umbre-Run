using UnityEngine;

public class Player : Person
{

    [SerializeField] private bool encountedGimmick; //Gimmick�ɑ����������ǂ����̃t���O�Bfalse�Ȃ�Run����
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
            Debug.Log("Gimmick�ɏՓ�");
            EncountedGimmickTrue();
        }
    }

    // EncountedGimmick�𑀍삷�郁�\�b�h
    // Gimmick���Ŏg�p����
    private void EncountedGimmickTrue()
    {
        encountedGimmick = true;
    }
    public void EncountedGimmickFalse()
    {
        encountedGimmick = false;
    }
}
