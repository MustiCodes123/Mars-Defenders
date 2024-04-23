using UnityEngine;

public class LaserMovement : MonoBehaviour
{
    private Transform target; 
    private Vector3 direction; 
    public float speed = 70f; 
    public GameObject impactEffect; 
    public AudioClip destroySound;

    private bool hasPlayedSound = false; 

    private void Start()
    {
        if (target != null)
        {
            direction = (target.position - transform.position).normalized;
        }
    }

    private void Update()
    {
        MoveTowardsTarget();
    }

    private void MoveTowardsTarget()
    {
        if (target == null)
        {
            DestroyBullet();
            return;
        }

        float distanceThisFrame = speed * Time.deltaTime;

        transform.Translate(direction * distanceThisFrame, Space.World);
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<TakeDamage>().TakeDamageForPlayer(5);

            Debug.Log("Bullet hit player");
            HitTarget();
        }
    }
    private void HitTarget()
    {
        if (impactEffect != null)
        {
            Instantiate(impactEffect, transform.position, Quaternion.identity);
        }

        DestroyBullet();

    }

    private void DestroyBullet()
    {
        if (!hasPlayedSound && destroySound != null)
        {
            AudioSource.PlayClipAtPoint(destroySound, transform.position);
            hasPlayedSound = true;
        }

        Destroy(gameObject);


    }
}
