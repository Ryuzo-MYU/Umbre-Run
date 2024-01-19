using UnityEngine;

public class AirFlow : Gimmick
{
    [SerializeField] private float airPower;
    [SerializeField] private float time;

    /// <summary>
    /// AirFlow�N���A���̏���
    /// Player����ɔ�΂�
    /// time�̃t���[�����������s��
    /// </summary>
    protected override void GimmickCleared()
    {

        if (time > 0)
        {
            // Player����ɔ�΂�
            Vector2 airVector = Vector2.up * airPower;
            Rigidbody2D plrb = player.GetComponent<Rigidbody2D>();
            plrb.AddForce(airVector, ForceMode2D.Impulse);
            time--;
        }
    }
}
