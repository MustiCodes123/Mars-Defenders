using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float bulletLifetime = 1.5f;

    private void Start()
    {
        Destroy(gameObject, bulletLifetime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);

            Destroy(other.gameObject);
        }
    }
}
