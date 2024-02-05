using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;  // �A�j���[�^�[�R���|�[�l���g�擾�p
    private Player player; // Player�R���|�[�g�擾�p

    // Start is called before the first frame update
    void Start()
    {
        // �A�j���[�^�[�R���|�[�l���g�擾
        animator = gameObject.GetComponent<Animator>();
        // Player�R���|�[�l���g�擾
        player = gameObject.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isStop()) { animator.SetBool("wait", true); }
        else { animator.SetBool("wait", false); }
    }
}
