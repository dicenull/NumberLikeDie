using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed = 20f;
    [SerializeField] private Key leftKey = Key.A;
    [SerializeField] private Key rightKey = Key.D;

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;
        if (keyboard[leftKey].isPressed)
        {
            Rotate(Vector3.down);
        }
        else if (keyboard[rightKey].isPressed)
        {
            Rotate(Vector3.up);
        }

    }

    void Rotate(Vector3 direction)
    {
        // 左右回転のみ
        var rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        var move = rotation * direction;
        transform.Rotate(move * Speed * Time.deltaTime);
    }
}
