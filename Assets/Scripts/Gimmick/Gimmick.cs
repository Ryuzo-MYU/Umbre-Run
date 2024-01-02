using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour
{
    [SerializeField] Umbrella umbrella;
    [SerializeField] string direction;
    [SerializeField] bool isOpen;
    [SerializeField] bool isCollisionedPlayer;

    public static event Action<Gimmick> OnDestroyed;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("collisioned!");
            Transform umbTransform = collision.gameObject.transform.GetChild(0);
            var _umbrella = umbTransform;
            umbrella = _umbrella.GetComponent<Umbrella>();
            isCollisionedPlayer = true;
        }
    }

    private void Update()
    {
        if (isCollisionedPlayer)
        {
            if (IsMatchingUmbrella(umbrella.direction, umbrella.isOpen))
            {
                Debug.Log("正しいコマンドが確認されました");
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }

    private bool IsMatchingUmbrella(string direction, bool isOpen)
    {
        return direction == this.direction && isOpen == this.isOpen;
    }
}
