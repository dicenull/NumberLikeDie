using R3;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }

    public ReactiveProperty<int> Score = new(0);

    public Subject<Unit> OnGameOver = new();

    GameData()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void AddScore(int value)
    {
        if (value < 0) return;
        Score.Value += value;
    }

    public void Reset()
    {
        Score.Value = 0;
    }

}
