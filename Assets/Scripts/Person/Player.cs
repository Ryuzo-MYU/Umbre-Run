using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Person
{

    [SerializeField] private bool encountedGimmick; //Gimmickに遭遇したかどうかのフラグ。falseならRunする
    public bool EncountedGimmick
    {
        // encountedGimmickのプロパティ
        get { return encountedGimmick; }
        set { encountedGimmick = value; }
    }
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        encountedGimmick = false;
    }


    private void FixedUpdate()
    {
        if (!encountedGimmick) { Run(rb, speed); }
        else { Stop(rb); }
    }
}
