using Unity.VisualScripting;
using UnityEngine;

public class AirFlow : Gimmick
{
    [SerializeField] private float airPower;
    [SerializeField] private float remainWorkTime;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    /// <summary>
    /// AirFlowクリア時の処理
    /// Playerを上に飛ばす
    /// timeのフレーム分処理を行う
    /// </summary>
    protected override void GimmickCleared(GameObject gameobject)
    {
        float time = remainWorkTime;

        if (time > 0)
        {
            Debug.Log("AirFlow起動");
            // Playerを上に飛ばす
            Vector2 airVector = Vector2.up * airPower;
            Rigidbody2D rb = gameobject.GetComponent<Rigidbody2D>();
            rb.AddForce(airVector, ForceMode2D.Impulse);

            // SE再生
            audioSource = GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioClip);

            time--;
        }
        else
        {
            gameobject = null;
        }
    }
}
