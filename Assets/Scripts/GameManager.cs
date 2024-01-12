using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private Goal goal;
    [SerializeField] private Chaser chaser;
    [SerializeField] private GameObject gameClearUI;
    [SerializeField] private GameObject gameOverUI;

    void Start()
    {
        Time.timeScale = 1.0f;
    }

    void Update()
    {
        if (goal != null && goal.isTouchedPlayer)
        {
            Debug.Log("Goal !!!");
            Time.timeScale = 0f;
            ShowGameClearUI(gameClearUI);
        }

        else if (chaser != null && chaser.isTouchedPlayer)
        {
            Time.timeScale = 0f;
            ShowGameOverUI(gameOverUI);
        }
    }

    /// <summary>
    /// �Q�[���N���A����UI��\������
    /// </summary>
    /// <param name="gameOverUI"></param>
    private void ShowGameClearUI(GameObject gameClearUI)
    {
        gameClearUI.SetActive(true);
    }

    /// <summary>
    /// �Q�[���I�[�o�[����UI��\������
    /// </summary>
    /// <param name="gameOverUI"></param>
    private void ShowGameOverUI(GameObject gameOverUI)
    {
        gameOverUI.SetActive(true);
    }

    /// <summary>
    /// �Q�[���V�[��������������
    /// GameOverUI��Button�I�u�W�F�N�g���Q�Ƃ��Ă���
    /// </summary>
    public void LoadCurrentScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
