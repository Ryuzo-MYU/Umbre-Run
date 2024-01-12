using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour
{
    public bool isCollisionedPlayer;
    public bool GimmickActivated = false;

    // �M�~�b�N���Ƃ̐����������E�J���
    public string direction;
    public bool isOpen;

    // �v���C���[�֘A�̏��
    public GameObject player;
    public Umbrella umbrella;

    //public static event Action<Gimmick> OnCleared;

    private void Start()
    {
        GimmickActivated = false;
    }

    private void Update()
    {
        // �����v���C���[�ƐڐG���Ă��āA���A�P�̃R�}���h�����������̂Ȃ�A�M�~�b�N�N���A���̏��������s����
        if (isCollisionedPlayer &&
            IsMatchingUmbrella(umbrella.direction, umbrella.isOpen))
        {
            GimmickCleared();
        }
    }

    /// <summary>
    /// �Փˎ��̏���
    /// Player��Umbrella�̃X�N���v�g���擾����
    /// isCollisionedPlayer��true�ɂ���
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GimmickActivated)
        {
            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("collisioned!");

                // Player�̎擾
                player = collision.gameObject;
                player.GetComponent<Player>().EncountedGimmick = true;

                // Umbrella�X�N���v�g�̎擾
                var _umb = collision.gameObject.transform.GetChild(0);
                umbrella = _umb.GetComponent<Umbrella>();

                isCollisionedPlayer = true;
            }
            GimmickActivated = true;
        }
    }


    /// <summary>
    /// �M�~�b�N�N���A���̏���
    /// �e��M�~�b�N�ł��̊֐����I�[�o�[���C�h����
    /// </summary>
    public virtual void GimmickCleared() { }

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
