using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject gameClearUI;
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private BGMController bgmController;

    public void GameClear()
    {
        Debug.Log("Goal !!!");
        Time.timeScale = 0f;
        bgmController.GameClear();
        ShowGameClearUI(gameClearUI);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        bgmController.GameOver();
        ShowGameOverUI(gameOverUI);
    }

    /// <summary>
    /// ゲームシーンを初期化する
    /// GameOverUIのButtonオブジェクトが参照している
    /// </summary>
    public void LoadCurrentScene()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
        Time.timeScale = 1.0f;
    }

    /// <summary>
    /// ゲームクリア時のUIを表示する
    /// </summary>
    /// <param name="gameOverUI"></param>
    private void ShowGameClearUI(GameObject gameClearUI)
    {
        gameClearUI.SetActive(true);
    }

    /// <summary>
    /// ゲームオーバー時のUIを表示する
    /// </summary>
    /// <param name="gameOverUI"></param>
    private void ShowGameOverUI(GameObject gameOverUI)
    {
        gameOverUI.SetActive(true);
    }
}
