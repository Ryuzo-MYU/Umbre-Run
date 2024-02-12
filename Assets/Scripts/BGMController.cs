using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMController : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip defaultBGMClip;
    [SerializeField] AudioClip gameClearBGMClip;
    [SerializeField] AudioClip gameOverBGMClip;



    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = defaultBGMClip;
        audioSource.Play();
    }

    public void GameClear()
    {
        audioSource.clip = gameClearBGMClip;
        audioSource.Play();
    }
    public void GameOver()
    {
        audioSource.clip = gameOverBGMClip;
        audioSource.Play();
    }
}
