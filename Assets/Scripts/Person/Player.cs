using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Person
{

    [SerializeField] private bool encountedGimmick; //Gimmick�ɑ����������ǂ����̃t���O�Bfalse�Ȃ�Run����
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        encountedGimmick = false;
    }

    public bool EncountedGimmick
    {
        // encountedGimmick�̃v���p�e�B
        get { return encountedGimmick; }
        set { encountedGimmick = value; }
    }

    private void FixedUpdate()
    {
        if (!encountedGimmick) { Run(rb, speed); }
        else { Stop(rb); }
    }
}
