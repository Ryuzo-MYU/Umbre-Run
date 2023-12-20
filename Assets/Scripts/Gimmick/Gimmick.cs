using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private (string, bool) umbrellaCommand;

    public (string, bool) rightCommand;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("collisioned!");
            player = collision.gameObject.GetComponent<GameObject>();

            GameObject umbrella;
            umbrella = player.gameObject.transform.GetChild(0).gameObject;
        }
    }

    private void Update()
    {
        if(umbrellaCommand == rightCommand)
        {
            GimmickCleared();
        }
    }

    public virtual void GimmickCleared()
    {

    }
}
