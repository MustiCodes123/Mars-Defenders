using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform gunTransform;
    public GameObject bulletPrefab;
    public float fireRate = 5f;
    private float nextFireTime;

    // Update is called once per frame
    void Update()
    {
        // Check if 'Z' key is pressed and if it's time to fire
        if (Input.GetKeyDown(KeyCode.Z) && Time.time >= nextFireTime)
        {
            // Calculate the position to spawn the bullet (just in front of the gun)
            Vector3 spawnPosition = gunTransform.position + gunTransform.right * 0.5f;

            // Spawn the bullet
            GameObject bullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);

            // Set the bullet's initial velocity to make it travel to the right
            Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
            bulletRB.velocity = new Vector2(10f, 0f); // Adjust the velocity as needed

            // Update the next fire time based on fire rate
            nextFireTime = Time.time + 1f / fireRate;
        }
    }
}
