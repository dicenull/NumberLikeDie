using R3;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData Instance { get; private set; }

    public ReactiveProperty<int> Score = new(0);

    public Subject<Unit> OnGameOver = new();

    public ReactiveProperty<int> Hp = new(MaxHP);

    public static int MaxHP = 15;

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

    void Start()
    {
        Hp
            .Where((hp) => hp <= 0)
            .Subscribe((_) => OnGameOver.OnNext(Unit.Default));
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
