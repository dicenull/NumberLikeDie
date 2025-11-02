using R3;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Slider _hpSlider;

    void Start()
    {
        GameData.Instance.Score
          .Select((score) => $"Score: {score}")
          .Subscribe((t) => _scoreText.text = t)
          .AddTo(this);

        GameData.Instance.Hp
            .Select((hp) => (float)hp / GameData.MaxHP)
            .Subscribe((value) => _hpSlider.value = value)
            .AddTo(this);
    }
}
