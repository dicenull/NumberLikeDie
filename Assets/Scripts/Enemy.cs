using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(gameObject, 0.05f);
        }
    }
}
