using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    bool isActive = true;

    const float coolDownTime = 0.3f;
    float currentTime = 0f;

    const float range = 40f;
    const float enemySpeed = 3f;


    void Update()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        if (!isActive) return;
        if (Time.time - currentTime < coolDownTime) return;
        currentTime = Time.time;

        // 円の外周からランダムに出現
        float angle = Random.Range(0f, Mathf.PI * 2);
        Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * range;
        var enemy = Instantiate(enemyPrefab, pos, Quaternion.identity);

        // 中心に向かって進む
        enemy.GetComponent<Rigidbody>().AddForce((Vector3.zero - pos).normalized * enemySpeed, ForceMode.VelocityChange);
    }
}
