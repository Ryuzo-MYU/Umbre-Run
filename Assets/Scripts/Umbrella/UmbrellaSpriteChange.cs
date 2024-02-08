using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaSpriteChange : MonoBehaviour
{
    [SerializeField] private Sprite open;
    [SerializeField] private Sprite close;
    [SerializeField] private Umbrella umbrella;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        umbrella = gameObject.GetComponent<Umbrella>();
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        SpriteCahnge(umbrella, spriteRenderer);
    }

    void SpriteCahnge(Umbrella umbrella, SpriteRenderer spriteRenderer)
    {
        if (umbrella.GetIsOpen()) { spriteRenderer.sprite = open; }
        else { spriteRenderer.sprite = close; }
    }
}
