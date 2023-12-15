using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;
    [SerializeField] GameObject umbrella;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("collisioned!");
            player = collision.gameObject.GetComponent<Rigidbody2D>();
            umbrella = player.gameObject.transform.GetChild(0).gameObject;
        }
    }
}
