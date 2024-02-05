using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;  // アニメーターコンポーネント取得用
    private Player player; // Playerコンポート取得用

    // Start is called before the first frame update
    void Start()
    {
        // アニメーターコンポーネント取得
        animator = gameObject.GetComponent<Animator>();
        // Playerコンポーネント取得
        player = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isStop()) { animator.SetBool("wait", true); }
        else { animator.SetBool("wait", false); }
    }
}
