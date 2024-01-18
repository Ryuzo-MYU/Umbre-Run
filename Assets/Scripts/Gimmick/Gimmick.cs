using UnityEngine;

public class Gimmick : MonoBehaviour
{
    private bool gimmickCollisioned; //�Փ˃t���O
    public bool isWorkAgain; // ������N�����邩�H
    private bool isWorked; // �N���ς݃t���O

    // �M�~�b�N���Ƃ̐����������E�J���
    public string direction;
    public bool isOpen;

    // �v���C���[�֘A�̏��
    public GameObject player;
    public Player pl;
    public Umbrella umbrella;

    //public static event Action<Gimmick> OnCleared;

    private void Start()
    {
        gimmickCollisioned = false;
    }

    private void Update()
    {
        // �v���C���[�ƐڐG���Ă��āA�܂��N�����Ă��Ȃ��Ȃ�R�}���h������s���B
        // �R�}���h�ɉ����āA�M�~�b�N���ƂɃN���A���E���s���̏������s��
        if (gimmickCollisioned && !isWorked)
        {
            if (IsMatchingUmbrella(umbrella.direction, umbrella.isOpen))
            {
                GimmickCleared();
                this.gameObject.GetComponent<Collider2D>().enabled = false;
            }
            else
            {
                GimmickFailed();
            }
            isWorked = true;
            pl.EncountedGimmickFalse();
        }
    }

    /// <summary>
    /// �Փˎ��̏���
    /// Player��Umbrella�̃X�N���v�g���擾����
    /// GimmickActivated��true�ɂ���
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("collisioned!");

            // Player�X�N���v�g�̎擾
            player = collision.gameObject;
            pl = player.GetComponent<Player>();

            // Umbrella�X�N���v�g�̎擾
            var _umb = collision.gameObject.transform.GetChild(0);
            umbrella = _umb.GetComponent<Umbrella>();

            gimmickCollisioned = true;
        }
    }


    /// <summary>
    /// �M�~�b�N�N���A���̏���
    /// �e��M�~�b�N�ł��̊֐����I�[�o�[���C�h����
    /// </summary>
    public virtual void GimmickCleared() { }

    /// <summary>
    /// �M�~�b�N���s���̏���
    /// �e��M�~�b�N�ł��̊֐����I�[�o�[���C�h����
    /// </summary>
    public virtual void GimmickFailed() { }

    /// <summary>
    /// �P�̌����E�J��Ԃ��A�����̐����R�}���h�ƍ����Ă��邩�𔻒肷��
    /// </summary>
    /// <param name="direction"> �P�̕��� </param>
    /// <param name="isOpen"> �P�̊J��� </param>
    /// <returns>
    /// �P�̃R�}���h�������̐����R�}���h�ƈ�v �� true
    /// ��v���Ă��Ȃ�                         �� false
    /// </returns>
    private bool IsMatchingUmbrella(string direction, bool isOpen)
    {
        return direction == this.direction && isOpen == this.isOpen;
    }
}
