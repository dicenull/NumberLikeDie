using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float Speed = 20f;
    [SerializeField] private Key leftKey = Key.A;
    [SerializeField] private Key rightKey = Key.D;

    const float coolDownTime = 0.1f;
    float currentTime = 0f;

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

        if (keyboard[Key.Space].isPressed)
        {
            Shot();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Time.timeScale = 0f; // ゲームオーバー
        }
    }

    void Shot()
    {
        if (Time.time - currentTime < coolDownTime) return;
        currentTime = Time.time;
        var bullet = Instantiate(Resources.Load<GameObject>("Bullet"), transform.position + transform.forward * 2, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * 20f, ForceMode.Impulse);
        Destroy(bullet, 10f);
    }

    void Rotate(Vector3 direction)
    {
        // 左右回転のみ
        var rotation = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0);
        var move = rotation * direction;
        transform.Rotate(move * Speed * Time.deltaTime);
    }
}
