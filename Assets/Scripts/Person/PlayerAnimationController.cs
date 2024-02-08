using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private Player player;

    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        player = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isRunning()) { animator.SetBool("wait", false); }
        else { animator.SetBool("wait", true); }
    }
}
