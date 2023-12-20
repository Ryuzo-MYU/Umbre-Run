using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private bool isRunning;
    [SerializeField] private bool encountedGimmick;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (!encountedGimmick) { isRunning = true; }

        if (isRunning) { run(rb, speed); }
    }

    private void run(Rigidbody2D rb, float speed)
    {
        rb.velocity = transform.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Gimmick") { 
            encountedGimmick = true;
            Debug.Log("Player met Gimmick");
        }
    }

}
