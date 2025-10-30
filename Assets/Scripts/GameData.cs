using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }

    public int Score { get; private set; } = 0;

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
        Score += value;
    }

}
