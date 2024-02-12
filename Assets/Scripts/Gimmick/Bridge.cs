using UnityEngine;

public class Bridge : Gimmick
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    protected override void GimmickCleared(GameObject gameobject)
    {
        Debug.Log("Bridge起動");
        GameObject bridgeChild = gameObject.transform.GetChild(0).gameObject;

        // SE再生
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(audioClip);

        bridgeChild.SetActive(true);
    }
}
