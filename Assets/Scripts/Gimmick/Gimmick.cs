using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour
{
    public bool isCollisionedPlayer;

    // �M�~�b�N���Ƃ̐����������E�J���
    public string direction;
    public bool isOpen;

    // �v���C���[�֘A�̏��
    public GameObject player;
    public Umbrella umbrella;

    public static event Action<Gimmick> OnDestroyed;

    private void OnTriggerEnter2D(Collider2D collision)
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
    }

    private void Update()
    {
        // �����v���C���[�ƐڐG���Ă�����A
        // �M�~�b�N�̃R�}���h���������
        if (isCollisionedPlayer)
        {
            if (IsMatchingUmbrella(umbrella.direction, umbrella.isOpen))
            {
                GimmickCleared();
            }
        }
    }

    /// <summary>
    ///     �M�~�b�N�N���A���̏���
    ///     �e��M�~�b�N�ł��̊֐����I�[�o�[���C�h���Ďg��
    /// </summary>
    public virtual void GimmickCleared() { }

    /// <summary>
    ///     �M�~�b�N�j�󎞂�
    /// </summary>
    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }

    /// <summary>
    ///     �P�̌����E�J��Ԃ��A�����̐����R�}���h
    ///     �ƍ����Ă��邩�𔻒肷��
    /// </summary>
    /// <param name="direction"> �P�̕��� </param>
    /// <param name="isOpen"> �P�̊J��� </param>
    /// <returns></returns>
    private bool IsMatchingUmbrella(string direction, bool isOpen)
    {
        return direction == this.direction && isOpen == this.isOpen;
    }
}
