using R3;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    readonly ReactiveProperty<int> Power = new(10);
    private float mergeCoolDown = 0f;

    public bool CanMerge()
    {
        return Time.time > mergeCoolDown;
    }

    void Start()
    {
        Power.Subscribe((p) =>
        {
            transform.localScale = Vector3.one * (1f + p * 0.1f);
        }).AddTo(this);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var otherScore = other.gameObject.GetComponent<Enemy>().Power.Value;
            // 吸収したらしばらくは消えない
            mergeCoolDown = Time.time + 0.2f;

            if (other.gameObject.GetComponent<Enemy>().CanMerge())
            {
                Destroy(other.gameObject);
                PowerUp(otherScore);
            }
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject, 0.05f);
            GameData.Instance.AddScore(Power.Value);
        }

        if (other.gameObject.CompareTag("PowerBullet"))
        {
            var bullet = other.gameObject;
            Destroy(bullet);
            PowerUp(10);
        }
    }

    void PowerUp(int score)
    {
        // ちょっとだけ後ろに飛ばす
        transform.position -= transform.forward * 1f;

        Power.Value += score;
    }
}
