using UnityEngine;
using R3;
using unityroom.Api;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverCanvas;

    void Start()
    {
        _gameOverCanvas.SetActive(false);

        GameData.Instance.OnGameOver
          .Subscribe((_) =>
          {
              ShowGameOver();
          })
          .AddTo(this);
    }

    void ShowGameOver()
    {
        Time.timeScale = 0f; // ゲームオーバー
        _gameOverCanvas.SetActive(true);

        UnityroomApiClient.Instance.SendScore(1, GameData.Instance.Score.Value, ScoreboardWriteMode.Always);
    }
}
