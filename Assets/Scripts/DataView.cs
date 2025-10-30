using R3;
using TMPro;
using UnityEngine;

public class DataView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _outputText;

    void Start()
    {
        GameData.Instance.Score
          .Select((score) => $"Score: {score}")
          .Subscribe((t) => _outputText.text = t)
          .AddTo(this);
    }

}
