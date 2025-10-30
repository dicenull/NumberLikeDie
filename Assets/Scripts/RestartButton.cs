using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Time.timeScale = 1f;

        GameData.Instance.Reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
